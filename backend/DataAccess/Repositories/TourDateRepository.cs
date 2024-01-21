using Domain.Common;
using Domain.Entities;
using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;

namespace DataAccess.Repositories
{
    public class TourDateRepository : BaseRepository<TourDate>, ITourDateRepository
    {
        public TourDateRepository(ReservationDbContext reservationDbContext) : base(reservationDbContext)
        {
        }
    }
}
