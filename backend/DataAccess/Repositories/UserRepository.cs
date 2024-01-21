using Domain.Common;
using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;
using HousingReservation.Domain.Entities;

namespace DataAccess.Repositories
{
    public class UserRepository : PagedRepository<User>, IUserRepository
    {
        public UserRepository(ReservationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
