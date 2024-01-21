using HousingReservation.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HousingReservation.DataAccess.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ReservationDbContext _reservationDbContext;
        protected readonly DbSet<TEntity> _dbSet;
        protected BaseRepository(ReservationDbContext reservationDbContext)
        {
            _reservationDbContext = reservationDbContext;
            _dbSet = _reservationDbContext.Set<TEntity>();
        }

        public virtual async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _dbSet.Where(e => !e.Deleted && e.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.Where(e => !e.Deleted).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(e => !e.Deleted).Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity?> FindOneAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void SetDeletedFlag(TEntity entity)
        {
            entity.Deleted = true;
            _dbSet.Update(entity);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
