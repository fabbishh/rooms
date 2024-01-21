using Domain.Enums;

namespace Application.Models
{
    public class TourReviewsRow
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public Guid TourId { get; set; }
        public string? TourName { get; set; }
        public AdminRequestStatus Status { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public int Rating { get; set; }
    }
}
