using Domain.Common;
using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;
using HousingReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public class PromoRowItemRepository : PagedRepository<PromoRowItem>, IPromoRowItemRepository
    {
        public PromoRowItemRepository(ReservationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<List<PromoRowItem>> GetAllAsync()
        {
            return await _dbSet
                .Include(pri => pri.Sanatorium)
                .ThenInclude(s => s.RoomGroups)
                .Include(pri => pri.Sanatorium)
                .ThenInclude(s => s.Photo)
                .ToListAsync();
        }

        public override Task<PromoRowItem?> GetByIdAsync(Guid id)
        {
            return _dbSet
                .Include(i => i.PromoRowPlan)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public override async Task<IEnumerable<PromoRowItem>> FindAsync(Expression<Func<PromoRowItem, bool>> predicate)
        {
            var query = _dbSet.Include(pri => pri.Sanatorium)
                .ThenInclude(s => s.RoomGroups)
                .Include(pri => pri.Sanatorium)
                .ThenInclude(s => s.Photo)
                .Include(i => i.PromoRowPlan)
                .Where(e => !e.Deleted)
                .AsQueryable();

            if (predicate is not null)
            {
                query = query.Where(predicate);
            }

            return await query.ToListAsync();
        }

        public override async Task<PromoRowItem?> FindOneAsync(Expression<Func<PromoRowItem, bool>> predicate)
        {
            var query = _dbSet
                .Include(i => i.PromoRowPlan)
                .AsQueryable();

            if(predicate is not null)
            {
                query = query.Where(predicate);
            }

            return await query.FirstOrDefaultAsync();
        }
    }
}
