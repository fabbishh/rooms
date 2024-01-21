using Application.Exceptions;
using Application.Models;
using Application.Services;
using Domain.Common;
using Domain.Entities;
using Domain.Enums;
using FluentEmail.Core;
using HousingReservation.Domain.Entities;
using HousingReservation.Domain.Models.Auth;
using Infrastructure.Services.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace HousingReservation.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly IUserCodeRepository _userCodeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AuthService> _logger;
        public AuthService(
            IUserRepository userRepository,
            IConfiguration configuration,
            ITokenService tokenService,
            IRefreshTokenRepository refreshTokenRepository,
            IUnitOfWork unitOfWork,
            IEmailService emailService,
            IUserCodeRepository userCodeRepository,
            ILogger<AuthService> logger
            )
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _tokenService = tokenService;
            _refreshTokenRepository = refreshTokenRepository;
            _unitOfWork = unitOfWork;
            _emailService = emailService;
            _userCodeRepository = userCodeRepository;
            _logger = logger;
        }

        public async Task Register(RegistrationModel model)
        {
            if (model.Email.IsNullOrEmpty() && model.PhoneNumber.IsNullOrEmpty()
                || !model.Email.IsNullOrEmpty() && !model.PhoneNumber.IsNullOrEmpty())
            {
                throw new InvalidDataException("Регистрация возможна либо с email, либо с номером телефона");
            }

            if (!model.Email.IsNullOrEmpty())
            {
                var existingUser = await _userRepository.FindAsync(u => u.Email == model.Email);
                if (existingUser.Any())
                {
                    throw new UserExistsException(model.Email, null);
                }

                var user = new User
                {
                    Id = Guid.NewGuid(),
                    DateCreated = DateTime.UtcNow,
                    Email = model.Email,
                    IsEmailConfirmed = false,
                    IsPhoneNumberConfirmed = false,
                    IsActive = false,
                };

                await _userRepository.AddAsync(user);
                //отправка подтверждения на email
            }

            if (!model.PhoneNumber.IsNullOrEmpty())
            {
                var existingUser = await _userRepository.FindAsync(u => u.PhoneNumber == model.PhoneNumber);
                if (existingUser.Any())
                {
                    throw new UserExistsException(model.PhoneNumber, null);
                }

                var user = new User
                {
                    Id = Guid.NewGuid(),
                    DateCreated = DateTime.UtcNow,
                    PhoneNumber = model.PhoneNumber,
                    IsEmailConfirmed = false,
                    IsPhoneNumberConfirmed = false,
                    IsActive = false,
                    Role = Role.User
                };

                await _userRepository.AddAsync(user);

                //Отправка sms с кодом
            }

            await _unitOfWork.SaveAsync();
        }

        public async Task<TokenModel> ValidateConfirmationCode(string code, string email, bool shouldUpdateConfirm)
        {
            var user = (await _userRepository.FindAsync(u => u.Email == email)).FirstOrDefault();
            if (user is null)
            {
                throw new UserNotFoundException(nameof(user));
            }

            var hashedCode = HashAuthCode(code);
            var isValidCode = await _userCodeRepository.IsCodeValid(hashedCode, user.Id);

            if(!isValidCode)
            {
                throw new InvalidAuthCodeException();
            }

            if (shouldUpdateConfirm)
            {
                user.IsEmailConfirmed = true;
                _userRepository.Update(user);
            }

            var authClaims = new List<Claim>
            {
               new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
               new Claim(ClaimTypes.Role, user.Role.ToString()),
               new Claim("email", user.Email!)
            };

            var accessToken = _tokenService.GenerateAccessToken(authClaims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            var userRefreshTokens = await _refreshTokenRepository.FindAsync(rt => rt.UserId == user.Id);

            if (userRefreshTokens is not null && userRefreshTokens.Any())
            {
                foreach (var token in userRefreshTokens)
                {
                    _refreshTokenRepository.Remove(token);
                }
            }

            await _refreshTokenRepository.AddAsync(new UserRefreshToken
            {
                Id = Guid.NewGuid(),
                DateCreated = DateTime.UtcNow,
                IsActive = true,
                Token = refreshToken,
                UserId = user.Id,
            });

            await _unitOfWork.SaveAsync();

            var tokenResult = new TokenModel
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };

            return tokenResult;
        }

        public async Task Login(LoginModel model)
        {
            if (model.Email is null && model.PhoneNumber is null
                || model.Email is not null && model.PhoneNumber is not null)
            {
                throw new InvalidDataException("Вход возможен либо с email, либо с номером телефона");
            }

            if (model.Email is not null)
            {
                var existingUser = await _userRepository.FindOneAsync(u => u.Email == model.Email);
                if (existingUser is null)
                {
                    existingUser = new User
                    {
                        Id = Guid.NewGuid(),
                        DateCreated = DateTime.UtcNow,
                        Email = model.Email,
                        IsEmailConfirmed = false,
                        IsPhoneNumberConfirmed = false,
                        IsActive = false,
                        Role = Role.User
                    };
                    await _userRepository.AddAsync(existingUser);
                    await _unitOfWork.SaveAsync();
                }  

                var authCode = GenerateAuthCode();
                var hashedCode = HashAuthCode(authCode);
                var userCode = new UserCode
                {
                    Id = Guid.NewGuid(),
                    UserId = existingUser.Id,
                    Expires = DateTimeOffset.UtcNow.AddMinutes(5),
                    Code = hashedCode,
                    DateCreated = DateTimeOffset.UtcNow,
                    IsActive = true,
                    Deleted = false,
                };
                await _userCodeRepository.AddAsync(userCode);
                await _unitOfWork.SaveAsync();

                await _emailService.Send(new Infrastructure.Models.EmailMetadata(existingUser!.Email!,"Подтверждение email", $"Код подтверждения: {authCode}"));
            }

            if (model.PhoneNumber is not null)
            {
                var existingUser = await _userRepository.FindAsync(u => u.PhoneNumber == model.PhoneNumber);
                if (!existingUser.Any())
                {
                    throw new UserNotFoundException(model.PhoneNumber);
                }

                // send sms confirm
            }
        }

        public async Task<TokenModel> Refresh(TokenModel token)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(token.AccessToken);
            var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                throw new UnauthorizedAccessException("Invalid attempt");
            }

            var user = await _userRepository.GetByIdAsync(new Guid(userId));
            if (user is null)
            {
                throw new UserNotFoundException(null);
            }

            var savedRefreshToken = (await _refreshTokenRepository.FindAsync(t => t.UserId.ToString() == userId && t.Token == token.RefreshToken))
                .FirstOrDefault();
            if (savedRefreshToken is null)
            {
                throw new UnauthorizedAccessException("Invalid attempt");
            }

            var authClaims = new List<Claim>
            {
               new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
               new Claim(ClaimTypes.Role, user.Role.ToString()),
               new Claim("email", user.Email!)
            };

            var newAccessToken = _tokenService.GenerateAccessToken(authClaims);
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            UserRefreshToken userRefreshToken = new UserRefreshToken
            {
                Id = Guid.NewGuid(),
                Token = newRefreshToken,
                UserId = new Guid(userId),
                IsActive = true,
                DateCreated = DateTime.UtcNow,
            };

            _refreshTokenRepository.Remove(savedRefreshToken);
            await _refreshTokenRepository.AddAsync(userRefreshToken);

            await _unitOfWork.SaveAsync();

            return new TokenModel { AccessToken = newAccessToken, RefreshToken = newRefreshToken };
        }

        private string GenerateAuthCode()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 6);
        }

        private string HashAuthCode(string code)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(code));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
