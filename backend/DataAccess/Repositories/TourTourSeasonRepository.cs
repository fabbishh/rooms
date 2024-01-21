using Domain.Common;
using Domain.Entities;
using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;

namespace DataAccess.Repositories
{
    public class TourTourSeasonRepository : BaseRepository<TourTourSeason>, ITourTourSeasonRepository
    {
        public TourTourSeasonRepository(ReservationDbContext reservationDbContext) : base(reservationDbContext)
        {
        }
    }
}
