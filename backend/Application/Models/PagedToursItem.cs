namespace Application.Models
{
    public class PagedToursItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? Type { get; set; }
        public int TouristCountFrom { get; set; }
        public int TouristCountTo { get; set; }
        public int Days { get; set; }
        public string Description { get; set; }
        public decimal? PriceByGroup { get; set; }
        public decimal? PriceByTourist { get; set; }
        public DateTimeOffset? ClosestDate { get; set; }
        public TourOrganizerDto Organizer { get; set; }

    }
}
