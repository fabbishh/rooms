using Domain.Enums;
using HousingReservation.Domain.Common;
using HousingReservation.Domain.Enums;

namespace HousingReservation.Domain.Entities
{
    public class RoomGroup : BaseEntity
    {
        public string? Name { get; set; }
        public decimal PricePerNight { get; set; }
        public int MinDaysReservation { get; set; }
        public RoomType RoomType { get; set; }
        public HousingType HousingType { get; set; }
        public int BedroomCount { get; set; }
        public int SingleBedCount { get; set; }
        public int DoubleBedCount { get; set; }
        public string Description { get; set; }
        public AdminRequestStatus Status { get; set; }

        public Guid SanatoriumId { get; set; }
        public Sanatorium Sanatorium { get; set; }

        public List<RoomAttribute> Attributes { get; set; }

        public List<Room> Rooms { get; set; } = new List<Room>();
        public int Quantity => Rooms.Where(r => !r.Deleted).Count();
        public List<Photo> Photos { get; set; } = new List<Photo>();
    }
}
