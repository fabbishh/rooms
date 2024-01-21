using webapi.DTO.Attributes;

namespace webapi.DTO.Rooms
{
    public class UpdateRoomsDto
    {   
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int SameRoomCount { get; set; }
        public int MinDaysReservation { get; set; }
        public int RoomType { get; set; }
        public int BedroomCount { get; set; }
        public int SingleBedCount { get; set; }
        public int DoubleBedCount { get; set; }
        public decimal PricePerNight { get; set; }
        public string Description { get; set; }
        public Guid SanatoriumId { get; set; }
        public int Type {  get; set; }
        public int Status { get; set; }
        public List<RoomAttributeRequest> ComfortAttributes { get; set; }
        public List<RoomAttributeRequest> FoodAttributes { get; set; }
        public List<RoomAttributeRequest> BathroomAttributes { get; set; }
        public List<IFormFile>? Photos { get; set; }
        public List<Guid> DeletedPhotos { get; set; } = new List<Guid>();
    }
}
