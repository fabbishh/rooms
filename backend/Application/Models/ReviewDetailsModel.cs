using Domain.Enums;

namespace Application.Models
{
    internal class ReviewDetailsModel
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public AuthorModel? Author { get; set; }
        public AdminRequestStatus? Status { get; set; }
        public string? Comment { get; set; }
        public int OverallRating { get; set; }
        public int StaffRating { get; set; }
        public int CleanlinessRating { get; set; }
        public int TherapyRating { get; set; }
        public int FoodRating { get; set; }
        public int LocationRating { get; set; }
        public int EntertainmentRating { get; set; }
        public Guid SanatoriumId { get; set; }
        public string? SanatoriumName { get; set; }
    }
}
