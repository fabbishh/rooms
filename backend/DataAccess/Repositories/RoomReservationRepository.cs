using Domain.Common;
using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;
using HousingReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class RoomReservationRepository : PagedRepository<RoomReservation>, IRoomReservationRepository
    {
        public RoomReservationRepository(ReservationDbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<RoomReservation> PagedQuery()
        {
            return base.PagedQuery()
                    .Include(r => r.Room)
                    .ThenInclude(rm => rm.Group)
                    .Include(r => r.User);
        }

        public override async Task<RoomReservation?> GetByIdAsync(Guid id)
        {
            return await _dbSet
                .Include(r => r.Room)
                .ThenInclude(rm => rm.Group)
                .Include(r => r.User)
                .Include(r => r.Guests)
                .FirstOrDefaultAsync(r => r.Id == id && !r.Deleted);
        }
    }
}
