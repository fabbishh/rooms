using Domain.Common;
using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;
using HousingReservation.Domain.Entities;

namespace DataAccess.Repositories
{
    public class PromoBlockRepository : BaseRepository<PromoBlock>, IPromoBlockRepository
    {
        public PromoBlockRepository(ReservationDbContext reservationDbContext) : base(reservationDbContext)
        {
        }
    }
}
