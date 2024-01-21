using HousingReservation.Domain.Common;
using HousingReservation.Domain.Entities;

namespace Domain.Entities
{
    public class Guest : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Patronymic { get; set; }
        public Guid RoomReservationId { get; set; }
        public RoomReservation RoomReservation { get; set; }
    }
}
