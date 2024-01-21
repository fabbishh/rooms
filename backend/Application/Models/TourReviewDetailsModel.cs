using Domain.Enums;

namespace Application.Models
{
    public class TourReviewDetailsModel
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public AuthorModel? Author { get; set; }
        public AdminRequestStatus? Status { get; set; }
        public string? Comment { get; set; }
        public int OverallRating { get; set; }
        public Guid TourId { get; set; }
        public string? TourName { get; set; }
    }
}
