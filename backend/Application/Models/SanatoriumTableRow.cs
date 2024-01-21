using Domain.Enums;

namespace Application.Models
{
    public class SanatoriumTableRow
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string CheckInTime { get; set; }
        public string CheckOutTime { get; set; }
        public SanatoriumSeason Season { get; set; }
        public string ObjectType { get; set; }
        public string Owner { get; set; }
        public AdminRequestStatus Status { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
