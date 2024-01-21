namespace Application.Models
{
    public class RoomFormData
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int? SameRoomCount { get; set; }
        public int? MinDaysReservation { get; set; }
        public int? RoomType { get; set; }
        public int? BedroomCount { get; set; }
        public int? SingleBedCount { get; set; }
        public int? DoubleBedCount { get; set; }
        public decimal? PricePerNight { get; set; }
        public string? Description { get; set; }
        public int Status { get; set; }
        public Guid? SanatoriumId { get; set; }
        public List<RoomAttributeDto> ComfortAttributes { get; set; } = new List<RoomAttributeDto>();
        public List<RoomAttributeDto> FoodAttributes { get; set; } = new List<RoomAttributeDto>();
        public List<RoomAttributeDto> BathroomAttributes { get; set; } = new List<RoomAttributeDto>();
        public List<PhotoModel>? Photos { get; set; }
    }
}
