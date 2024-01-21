using Domain.Enums;

namespace Application.Models
{
    public class ToursTableRow
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public AdminRequestStatus Status { get; set; }
        public List<DateTimeOffset> ClosestDates { get; set; } = new List<DateTimeOffset>();
        public string PromoInfo { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public Guid TourAgencyId { get; set; }
        public string TourAgencyName { get;set;}
    }
}
