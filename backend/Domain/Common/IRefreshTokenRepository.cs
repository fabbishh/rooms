using Domain.Entities;
using HousingReservation.Domain.Common;

namespace Domain.Common
{
    public interface IRefreshTokenRepository : IBaseRepository<UserRefreshToken>
    {
    }
}
