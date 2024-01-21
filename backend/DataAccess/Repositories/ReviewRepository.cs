using Domain.Common;
using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;
using HousingReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ReviewRepository : PagedRepository<Review>, IReviewRepository
    {
        public ReviewRepository(ReservationDbContext dbContext) : base(dbContext) { }

        protected override IQueryable<Review> PagedQuery()
        {
            return base.PagedQuery()
                .Include(r => r.User)
                .Include(r => r.Sanatorium);
        }

        public override Task<Review?> GetByIdAsync(Guid id)
        {
            return _dbSet
                .Include(r => r.User)
                .Include(r => r.Sanatorium)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
