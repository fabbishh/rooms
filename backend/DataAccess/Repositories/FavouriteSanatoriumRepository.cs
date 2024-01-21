using Domain.Common;
using Domain.Entities;
using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class FavouriteSanatoriumRepository : PagedRepository<FavouriteSanatorium>, IFavouriteSanatoriumRepository
    {
        public FavouriteSanatoriumRepository(ReservationDbContext dbContext) : base(dbContext)
        {
        }
        protected override IQueryable<FavouriteSanatorium> PagedQuery()
        {
            return base.PagedQuery()
                .Include(s => s.Sanatorium)
                .ThenInclude(s => s.Photo)
                .Include(s => s.Sanatorium)
                .ThenInclude(s => s.Owner)
                .Include(s => s.Sanatorium)
                .ThenInclude(s => s.Type)
                .Include(s => s.Sanatorium)
                .ThenInclude(s => s.RoomGroups)
                .Include(s => s.Sanatorium)
                .ThenInclude(s => s.Subject);
        }
    }
}
