using HousingReservation.Domain.Common;
using HousingReservation.Domain.Entities;

namespace Domain.Common
{
    public interface ITourDateBookingRepository : IBaseRepository<TourDateBooking>
    {
        Task<int> GetTourDateBookingCount(Guid tourDateId);
    }
}
