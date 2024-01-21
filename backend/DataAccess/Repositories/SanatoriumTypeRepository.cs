using Domain.Common;
using Domain.Entities;
using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;

namespace DataAccess.Repositories
{
    public class SanatoriumTypeRepository : BaseRepository<SanatoriumType>, ISanatoriumTypeRepository
    {
        public SanatoriumTypeRepository(ReservationDbContext reservationDbContext) : base(reservationDbContext)
        {
        }
    }
}
