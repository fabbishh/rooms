using Application.Commands;
using Application.Exceptions;
using Domain.Common;
using Domain.Enums;
using HousingReservation.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers.Users
{
    internal class SaveUserCommandHandler : IRequestHandler<SaveUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SaveUserCommandHandler> _logger;
        public SaveUserCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, ILogger<SaveUserCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _logger = logger;
        }
        public async Task Handle(SaveUserCommand request, CancellationToken cancellationToken)
        {
            if(request.Id.HasValue)
            {
                var existingUser = await _userRepository.GetByIdAsync(request.Id.Value);
                if (existingUser is null)
                {
                    throw new UserNotFoundException(request.Id.ToString());
                }

                var existingEmail = await _userRepository.FindOneAsync(u => u.Email == request.Email && u.Id != request.Id);
                if (existingEmail is not null)
                {
                    throw new UserExistsException(email: existingEmail.Email, phoneNumber: null);
                }

                var existingPhone = await _userRepository.FindOneAsync(u => u.PhoneNumber == request.Phone && u.Id != request.Id);
                if (existingPhone is not null)
                {
                    throw new UserExistsException(phoneNumber: existingPhone.PhoneNumber, email: null);
                }

                existingUser.Gender = (UserGender)request.Gender;
                existingUser.Birthday = DateTime.SpecifyKind(request.Birthday, DateTimeKind.Utc);
                existingUser.FirstName = request.FirstName;
                existingUser.Patronymic = request.Patronymic;
                existingUser.LastName = request.LastName;
                existingUser.PhoneNumber = request.Phone;
                existingUser.Role = request.Role;

                _userRepository.Update(existingUser);
                await _unitOfWork.SaveAsync();
                _logger.LogInformation("Пользователь {@email} был обновлен", existingUser.Email);
            } 
            else 
            {
                var existingEmail = await _userRepository.FindOneAsync(u => u.Email == request.Email);
                if (existingEmail is not null)
                {
                    throw new UserExistsException(email: existingEmail.Email, phoneNumber: null);
                }

                var existingPhone = await _userRepository.FindOneAsync(u => u.PhoneNumber == request.Phone);
                if (existingPhone is not null)
                {
                    throw new UserExistsException(phoneNumber: existingPhone.PhoneNumber, email: null);
                }

                var user = new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Patronymic = request.Patronymic,
                    Birthday = request.Birthday,
                    Email = request.Email,
                    PhoneNumber = request.Phone,
                    Role = request.Role,
                    IsActive = true,
                    Deleted = false,
                    DateCreated = DateTimeOffset.UtcNow,
                    IsEmailConfirmed = true,
                    IsPhoneNumberConfirmed = true,
                };

                await _userRepository.AddAsync(user);
                await _unitOfWork.SaveAsync();
                _logger.LogInformation("Пользователь {@Email} был создан", user.Email);
            }
            
        }
    }
}
