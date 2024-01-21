using Domain.Common;
using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;
using HousingReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public class SanatoriumAttributeRepository : BaseRepository<SanatoriumAttribute>, ISanatoriumAttributeRepository
    {
        public SanatoriumAttributeRepository(ReservationDbContext reservationDbContext) : base(reservationDbContext)
        {
        }

        public override async Task<IEnumerable<SanatoriumAttribute>> FindAsync(Expression<Func<SanatoriumAttribute, bool>> predicate)
        {
            return await _dbSet
                .Include(sa => sa.Attribute)
                .ThenInclude(a => a.AttributeGroup)
                .Where(predicate)
                .ToListAsync();
        }
    }
}
