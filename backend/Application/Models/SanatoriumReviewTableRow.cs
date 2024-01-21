using Domain.Enums;

namespace Application.Models
{
    public class SanatoriumReviewTableRow
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public Guid SanatoriumId { get; set; }
        public string? SanatoriumName { get; set; }
        public AdminRequestStatus Status { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public int Rating {  get; set; }
    }
}
