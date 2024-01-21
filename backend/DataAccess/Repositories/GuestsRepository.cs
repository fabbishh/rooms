using Domain.Common;
using Domain.Entities;
using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;

namespace DataAccess.Repositories
{
    public class GuestsRepository : BaseRepository<Guest>, IGuestsRepository
    {
        public GuestsRepository(ReservationDbContext reservationDbContext) : base(reservationDbContext)
        {
        }
    }
}
