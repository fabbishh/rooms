using Domain.Common;
using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;
using HousingReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class TourRepository : PagedRepository<Tour>, ITourRepository
    {
        public TourRepository(ReservationDbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Tour> PagedQuery()
        {
            return base.PagedQuery()
                .Include(t => t.TourAgency)
                .Include(t => t.TourDates)
                .Include(t => t.Subject)
                .Include(t => t.Seasons)
                .ThenInclude(ts => ts.TourSeason);
        }

        public override async Task<Tour?> GetByIdAsync(Guid id)
        {
            return await _dbSet
                            .Include(t => t.TourAgency)
                            .Include (t => t.TourDates.Where(td => td.StartDate.Date >= DateTimeOffset.UtcNow.Date))
                            .Include(t => t.Subject)
                            .Include(t => t.Type)
                            .Include(t => t.Photos)
                            .Include(t => t.Seasons)
                            .ThenInclude(ts => ts.TourSeason)
                            .FirstOrDefaultAsync(t => t.Id == id && !t.Deleted); 
        }
    }
}
