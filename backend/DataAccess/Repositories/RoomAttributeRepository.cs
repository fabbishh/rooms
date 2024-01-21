using Domain.Common;
using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;
using HousingReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public class RoomAttributeRepository : BaseRepository<RoomAttribute>, IRoomAttributeRepository
    {
        public RoomAttributeRepository(ReservationDbContext reservationDbContext) : base(reservationDbContext)
        {
        }

        public override async Task<IEnumerable<RoomAttribute>> FindAsync(Expression<Func<RoomAttribute, bool>> predicate)
        {
            return await _dbSet
                .Include(ra => ra.Attribute)
                .ThenInclude(ra => ra.AttributeGroup)
                .Where(predicate).ToListAsync();
        }
    }
}
