using Domain.Entities;
using Domain.Enums;
using HousingReservation.Domain.Common;

namespace HousingReservation.Domain.Entities
{
    public class RoomReservation : BaseEntity
    {
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public int AdultGuestsCount { get; set; }
        public int ChildGuestsCount { get; set; }
        public string? GuestComment { get; set; }
        public string? SanatoriumAdminComment { get; set; }
        public string PhoneNumber { get; set; }

        public Guid RoomId { get; set; }
        public Room Room { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public AdminRequestStatus Status { get; set; }
        public List<Guest> Guests { get; set; } = new List<Guest>();
    }
}
