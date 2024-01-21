using Domain.Common;
using Domain.Entities;
using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class UserCodeRepository : BaseRepository<UserCode>, IUserCodeRepository
    {
        public UserCodeRepository(ReservationDbContext reservationDbContext) : base(reservationDbContext)
        {
        }

        public async Task<bool> IsCodeValid(string hashedCode, Guid userId)
        {
            var validCode = await _dbSet
                                .Where(c => !c.Deleted 
                                            && c.UserId == userId 
                                            && c.Code == hashedCode
                                            && c.Expires > DateTimeOffset.UtcNow)
                                .FirstOrDefaultAsync();

            return validCode is not null;
        }
    }
}
