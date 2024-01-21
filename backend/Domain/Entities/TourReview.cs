using Domain.Enums;
using HousingReservation.Domain.Common;
using HousingReservation.Domain.Entities;

namespace Domain.Entities
{
    public class TourReview : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
        public int OverallRating { get; set; }
        public AdminRequestStatus Status { get; set; }
        public Guid TourId { get; set; }
        public Tour Tour { get; set; }
    }
}
