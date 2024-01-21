using Domain.Enums;

namespace Application.Models
{
    public class PromoRowItemDto
    {
        public Guid Id { get; set; }
        public Guid SanatoriumId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? PhotoUrl { get; set; }
        public SanatoriumSeason Season { get; set; }
    }
}
