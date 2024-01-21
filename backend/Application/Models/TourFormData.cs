using Domain.Enums;

namespace Application.Models
{
    public class TourFormData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid Subject { get; set; }
        public string? SubjectName { get; set; }
        public bool IsActive { get; set; }
        public int Days { get; set; }
        public decimal Price { get; set; }
        public TourPriceType PriceType { get; set; }
        public int TouristCountFrom { get; set; }
        public int TouristCountTo { get; set; }
        public Guid Type { get; set; }
        public string? TypeName { get; set; }
        public Guid TourAgencyId { get; set; }
        public string? TourAgencyName { get; set; }
        public string Description { get; set; }
        public AdminRequestStatus Status { get; set; }
        public List<PhotoModel>? Photos { get; set; }
        public List<TourStartDate>? StartDates { get; set; }
        public List<int>? Seasons { get; set; }
    }
}
