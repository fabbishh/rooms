using HousingReservation.Domain.Common;
using HousingReservation.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HousingReservation.DataAccess.Repositories
{
    public abstract class PagedRepository<TEntity> : BaseRepository<TEntity>, IPagedRepository<TEntity> where TEntity : BaseEntity
    {
        public PagedRepository(ReservationDbContext dbContext) : base(dbContext) { }
        protected virtual IQueryable<TEntity> PagedQuery()
        {
            return _dbSet.Where(e => !e.Deleted).AsQueryable();
        }

        public virtual async Task<PagedResult<TEntity>> GetPagedAsync(
            int pageNumber,
            int pageSize,
            Expression<Func<TEntity, bool>>? filter = null
            )
        {
            var query = PagedQuery();
                

            if (filter != null)
            {
                query = query.Where(filter);
            }

            var totalItems = await query.CountAsync();

            var items = await query.OrderBy(e => e.DateCreated)
                                   .Skip((pageNumber - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync();

            return new PagedResult<TEntity>(items, totalItems, pageNumber, pageSize);
        }
    }
}
