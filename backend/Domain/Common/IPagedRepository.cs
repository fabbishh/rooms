using HousingReservation.Domain.Models;
using System.Linq.Expressions;

namespace HousingReservation.Domain.Common
{
    public interface IPagedRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<PagedResult<TEntity>> GetPagedAsync(
            int pageNumber,
            int pageSize,
            Expression<Func<TEntity, bool>>? filter = null);
    }
}
