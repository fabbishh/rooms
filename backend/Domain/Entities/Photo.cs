using HousingReservation.Domain.Common;

namespace HousingReservation.Domain.Entities
{
    public class Photo : BaseEntity
    {
        public string SmallUrl { get; set; }
        public string ThumbUrl { get; set; }
        public string OriginalUrl { get; set; }
        public string Path { get; set; }
        public Guid? RoomGroupId { get; set; }
        public RoomGroup? RoomGroup { get; set; }
        public Guid? TourId { get; set; }
        public Tour? Tour { get; set; }
        public Guid? PlaceId { get; set; }
        public Place? Place { get; set; }
    }
}
