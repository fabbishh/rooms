using Domain.Common;
using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;
using HousingReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public class RoomRepository : PagedRepository<Room>, IRoomRepository
    {
        public RoomRepository(ReservationDbContext dbContext) : base(dbContext) { }
        protected override IQueryable<Room> PagedQuery()
        {
            return base.PagedQuery()
                .Include(r => r.Group)
                .ThenInclude(rg => rg.Photos)
                .Include(r => r.Reservations);
        }

        public async Task<Room> GetRoomDetailsAsync(Guid roomId)
        {
            var room = await _dbSet
                .Include(r => r.Group)
                .ThenInclude(r => r.Photos)
                .FirstOrDefaultAsync(r => r.Id == roomId);

            return room!;
        }

        public override async Task<IEnumerable<Room>> FindAsync(Expression<Func<Room, bool>> predicate)
        {
            return await _dbSet.Include(r => r.Reservations).Where(predicate).ToListAsync();
        }
    }
}
