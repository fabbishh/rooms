namespace Application.Models
{
    public class PromoBlockItemModel
    {
        public Guid PromoBlockItemId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? PhotoUrl { get; set; }
        public Guid? SanatoriumId { get; set; }
        public Guid? RoomId { get; set; }
        public Guid? TourAgencyId { get; set; }
        public Guid? TourId { get; set; }

    }
}
