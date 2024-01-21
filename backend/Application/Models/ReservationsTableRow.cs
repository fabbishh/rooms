using Domain.Enums;

namespace Application.Models
{
    public class ReservationsTableRow
    {
        public Guid Id { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public string? RoomName { get; set; }
        public int GuestsCount { get; set; }
        public AdminRequestStatus Status { get; set; }
        public string? AuthorEmail { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
