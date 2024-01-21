namespace Application.Models
{
    public class RoomDto
    {
        public Guid RoomId { get; set; }
        public string? Name { get; set; }
        public decimal PricePerNight { get; set; }
        public int SingleBedCount { get; set; }
        public int DoubleBedCount { get; set; }
        public int BedroomCount { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public List<string> PhotoUrls { get; set; }
    }
}
