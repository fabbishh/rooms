using Domain.Enums;

namespace webapi.DTO.Tours
{
    public class SaveTourRequest
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Guid Type { get; set; }
        public int Days { get; set; }
        public int TouristCountFrom { get; set; }
        public int TouristCountTo { get; set; }
        public int PriceType { get; set; }
        public decimal Price { get; set; }
        public Guid Subject { get; set; }
        public string Description { get; set; }
        public Guid TourAgencyId { get; set; }
        public List<SaveTourDateRequest> StartDates { get; set; }
        public List<IFormFile>? Photos { get; set; }
        public List<Guid>? DeletedPhotos { get; set; }
        public List<int> Seasons { get; set; }
    }
}
