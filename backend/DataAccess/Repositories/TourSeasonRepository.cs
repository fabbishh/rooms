using Domain.Common;
using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;
using HousingReservation.Domain.Entities;

namespace DataAccess.Repositories
{
    public class TourSeasonRepository : BaseRepository<TourSeason>, ITourSeasonRepository
    {
        public TourSeasonRepository(ReservationDbContext reservationDbContext) : base(reservationDbContext)
        {
        }
    }
}
