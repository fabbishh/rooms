using Domain.Common;
using Domain.Entities;
using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class TourReviewRepository : PagedRepository<TourReview>, ITourReviewRepository
    {
        public TourReviewRepository(ReservationDbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TourReview> PagedQuery()
        {
            return base.PagedQuery()
                .Include(r => r.Tour)
                .Include(r => r.User);
        }
    }
}
