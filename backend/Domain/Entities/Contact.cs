using HousingReservation.Domain.Common;
using HousingReservation.Domain.Entities;

namespace Domain.Entities
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Guid? TourAgencyId { get; set; }
        public TourAgency? TourAgency { get; set; }

        public Guid? SanatoriumId { get; set; }
        public Sanatorium Sanatorium { get; set; }
    }
}
