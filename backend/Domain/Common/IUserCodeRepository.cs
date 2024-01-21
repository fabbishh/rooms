using Domain.Entities;
using HousingReservation.Domain.Common;

namespace Domain.Common
{
    public interface IUserCodeRepository : IBaseRepository<UserCode>
    {
        Task<bool> IsCodeValid(string hashedCode, Guid userId);
    }
}
