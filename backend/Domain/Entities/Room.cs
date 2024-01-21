using Domain.Common;
using HousingReservation.Domain.Common;
using HousingReservation.Domain.Enums;

namespace HousingReservation.Domain.Entities
{
    public class Room : BaseEntity
    {
        public string? Name { get; set; }
        public Guid GroupId { get; set; }
        public RoomGroup Group { get; set; }
        public List<RoomReservation> Reservations { get; set; } = new List<RoomReservation>();
    }
}
