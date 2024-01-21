using Application.Models;
using System.Security.Claims;

namespace Application.Services
{
    public interface ITokenService
    {
        public string GenerateRefreshToken();
        string GenerateAccessToken(IEnumerable<Claim> claims);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
