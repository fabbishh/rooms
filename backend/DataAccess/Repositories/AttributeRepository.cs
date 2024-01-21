using Domain.Common;
using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public sealed class AttributeRepository : BaseRepository<HousingReservation.Domain.Entities.Attribute>, IAttributeRepository
    {
        public AttributeRepository(ReservationDbContext dbContext) : base(dbContext) { }

/*        public override async Task<IEnumerable<HousingReservation.Domain.Entities.Attribute>> FindAsync(Expression<Func<HousingReservation.Domain.Entities.Attribute, bool>> predicate)
        {
            return await _dbSet
                .Include(p => p.AttributeGroup)
                .Where(predicate)
                .ToListAsync();
        }*/
    }
}
