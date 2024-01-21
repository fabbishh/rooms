namespace webapi.DTO.Reviews
{
    public class ReviewFilter : BaseFilter
    {
        public Guid? SanatoriumId { get; set; }
        public Guid? TourId { get; set; }
        public int Status { get; set; }
    }
}
