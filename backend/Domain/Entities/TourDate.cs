using HousingReservation.Domain.Common;
using HousingReservation.Domain.Entities;

namespace Domain.Entities
{
    public class TourDate : BaseEntity
    {
        public DateTimeOffset StartDate { get; set; }
        public Guid TourId { get; set; }
        public Tour Tour { get; set; }
        public List<TourDateBooking> TourBookings { get; set; } = new List<TourDateBooking>();
    }
}
