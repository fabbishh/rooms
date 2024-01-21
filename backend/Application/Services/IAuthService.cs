using Application.Models;
using HousingReservation.Domain.Models.Auth;

namespace HousingReservation.Application.Services
{
    public interface IAuthService
    {
        Task Register(RegistrationModel model);
        Task Login(LoginModel model);
        Task<TokenModel> ValidateConfirmationCode(string code, string phoneNumber, bool shouldUpdateConfirm);
        Task<TokenModel> Refresh(TokenModel token);
    }
}
