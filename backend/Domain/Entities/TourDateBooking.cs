using Domain.Entities;
using HousingReservation.Domain.Common;

namespace HousingReservation.Domain.Entities
{
    public class TourDateBooking : BaseEntity
    {
        public Guid TourDateId { get; set; }
        public TourDate TourDate { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
