using Domain.Common;
using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;
using HousingReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public class TourAgencyRepository : PagedRepository<TourAgency>, ITourAgencyRepository
    {
        public TourAgencyRepository(ReservationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<TourAgency?> GetByIdAsync(Guid id)
        {
            return await _dbSet
                .Include(s => s.Photo)
                .FirstOrDefaultAsync(s => s.Id == id && !s.Deleted);
        }

        public override async Task<TourAgency?> FindOneAsync(Expression<Func<TourAgency, bool>> predicate)
        {
            return await _dbSet.Include(t => t.Photo).Where(predicate).FirstOrDefaultAsync();
        }

        protected override IQueryable<TourAgency> PagedQuery()
        {
            return base.PagedQuery()
                    .Include(ta => ta.Owner);
        }
    }
}
