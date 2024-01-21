namespace Application.Models
{
    public class RoomDetailsModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int BedroomCount { get; set; }
        public int SingleBedCount { get; set; }
        public int DoubleBedCount { get; set; }
        public BathroomTypeDto BathroomType { get; set; }
        public MealTypeDto MealType { get; set; }
        public string Description { get; set; }
        public decimal PricePerNight { get; set; }
        public List<string>? PhotoUrls { get; set; }
        public List<AttributeDto> ComfortAttributes { get; set; }
        public Guid RoomGroupId { get; set; }
    }
}
