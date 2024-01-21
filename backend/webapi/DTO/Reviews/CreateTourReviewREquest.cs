namespace webapi.DTO.Reviews
{
    public class CreateTourReviewREquest
    {
        public Guid TourId { get; init; }
        public string Comment { get; init; }
        public int OverallRating { get; init; }
    }
}
