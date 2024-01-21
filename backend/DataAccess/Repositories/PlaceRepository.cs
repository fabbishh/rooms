using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;
using HousingReservation.Domain.Common;
using HousingReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public sealed class PlaceRepository : PagedRepository<Place>, IPlaceRepository
    {
        public PlaceRepository(ReservationDbContext dbContext) : base(dbContext) { }

        protected override IQueryable<Place> PagedQuery()
        {
            return base.PagedQuery()
                .Include(p => p.Subject)
                .Include(p => p.Photos)
                .Include(p => p.SanatoriumPlaces);
        }

        public override async Task<Place?> GetByIdAsync(Guid id)
        {
            return await _dbSet
                .Include(p => p.Subject)
                .Include(p => p.Photos)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
