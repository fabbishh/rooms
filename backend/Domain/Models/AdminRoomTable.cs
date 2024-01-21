
using Domain.Enums;

namespace HousingReservation.Domain.Models
{
    public class AdminRoomTable
    {
        public Guid RoomGroupId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Count {  get; set; }
        public Guid SanatoriumId { get; set; }
        public string SanatoriumName { get; set; }
        public AdminRequestStatus Status { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
