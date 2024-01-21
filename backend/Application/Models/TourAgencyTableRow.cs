using Domain.Enums;

namespace Application.Models
{
    public class TourAgencyTableRow
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Location { get; set; }
        public string? Link { get; set; }
        public AdminRequestStatus Status { get; set; }
        public bool IsActive { get; set; }
        public string Owner { get; set; }
        public DateTimeOffset? DateCreated { get; set; }
    }
}
