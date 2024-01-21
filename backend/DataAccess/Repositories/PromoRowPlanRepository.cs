using Domain.Common;
using Domain.Entities;
using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;

namespace DataAccess.Repositories
{
    public class PromoRowPlanRepository : BaseRepository<PromoRowPlan>, IPromoRowPlanRepository
    {
        public PromoRowPlanRepository(ReservationDbContext reservationDbContext) : base(reservationDbContext)
        {
        }
    }
}
