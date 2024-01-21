using Application.Models;
using HousingReservation.Application.Services;
using HousingReservation.Domain.Models.Auth;
using Microsoft.AspNetCore.Mvc;
using webapi.DTO.Auth;

namespace HousingReservation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authServise;

        public AuthController(IAuthService authService)
        {
            _authServise = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegistrationModel model)
        {
            await _authServise.Register(model);
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            await _authServise.Login(model);
            return Ok();
        }

        [HttpPost("ValidateCode")]
        public async Task<IActionResult> ValidateConfirmationCode(ValidateConfirmationCodeDto request)
        {
            var tokenResult = await _authServise.ValidateConfirmationCode(request.Code, request.Email, request.ShouldUpdateConfirm);

            return Ok(tokenResult);
        }

        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh(TokensDto model)
        {
            var tokenResult = await _authServise.Refresh(new TokenModel 
            { 
                AccessToken = model.AccessToken,
                RefreshToken = model.RefreshToken
            });

            return Ok(tokenResult);
        }
    }
}
