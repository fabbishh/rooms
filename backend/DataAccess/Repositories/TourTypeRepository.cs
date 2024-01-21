using Domain.Common;
using Domain.Entities;
using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;

namespace DataAccess.Repositories
{
    public class TourTypeRepository : BaseRepository<TourType>, ITourTypeRepository
    {
        public TourTypeRepository(ReservationDbContext reservationDbContext) : base(reservationDbContext)
        {
        }
    }
}
