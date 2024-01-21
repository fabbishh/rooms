using Domain.Common;
using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;
using HousingReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public class PromoBlockItemRepository : PagedRepository<PromoBlockItem>, IPromoBlockItemRepository
    {
        public PromoBlockItemRepository(ReservationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<PromoBlockItem>> FindAsync(Expression<Func<PromoBlockItem, bool>> predicate)
        {
            return await _dbSet
                .Include(i => i.PromoBlock)
                .Include(i => i.Sanatorium)
                .Include(i => i.Sanatorium == null ? null : i.Sanatorium.Photo)
                .Include(i => i.Room)
                .Include(i => i.Room == null ? null : i.Room.Group)
                .ThenInclude(g => g == null ? null : g.Photos)
                .Include(i => i.TourAgency)
                .Include(i => i.TourAgency == null ? null : i.TourAgency.Photo)
                .Include(i => i.Tour)
                .Include(i => i.Tour == null ? null : i.Tour.Photos)
                .Where(predicate)
                .ToListAsync();
        }

        public override async Task<PromoBlockItem?> FindOneAsync(Expression<Func<PromoBlockItem, bool>> predicate)
        {
            return await _dbSet
                .Include(i => i.PromoBlock)
                .Where(predicate)
                .FirstOrDefaultAsync();
        }
    }
}
