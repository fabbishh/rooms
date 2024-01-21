using Domain.Enums;

namespace Application.Models
{
    public class SanatoriumProfileDataDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid ObjectType { get; set; }
        public Guid SubjectId { get; set; }
        public string? PhotoUrl { get; set; }
        public string CheckInTime { get; set; }
        public string CheckOutTime { get; set; }
        public string Location { get; set; }
        public SanatoriumSeason Season { get; set; }
        public Guid OwnerId { get; set; }
        public AdminRequestStatus Status { get; set; }
    }
}
