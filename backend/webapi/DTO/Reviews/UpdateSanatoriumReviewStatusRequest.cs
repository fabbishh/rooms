namespace webapi.DTO.Reviews
{
    public class UpdateSanatoriumReviewStatusRequest
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
    }
}
