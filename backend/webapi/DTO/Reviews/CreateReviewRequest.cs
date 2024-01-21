using MediatR;

namespace webapi.DTO.Reviews
{
    public record CreateReviewRequest
    {
        public Guid SanatoriumId { get; init; }
        public string Comment { get; init; }
        public int OverallRating { get; init; }
        public int CleanlinessRating { get; init; }
        public int TherapyRating { get; init; }
        public int FoodRating { get; init; }
        public int LocationRating { get; init; }
        public int EntertainmentRating { get; init; }
        public int StaffRating { get; init; }
    }
}
