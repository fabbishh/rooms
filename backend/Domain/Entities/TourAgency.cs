using Domain.Entities;
using Domain.Enums;
using HousingReservation.Domain.Common;

namespace HousingReservation.Domain.Entities
{
    public class TourAgency : BaseEntity
    {
        public string Name { get; set; }
        public string? Location { get; set; }
        public string Email { get; set; }
        public string? Link { get; set; }
        public string? Description { get; set; }
        public AdminRequestStatus Status { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        public Guid? PhotoId { get; set; }
        public Photo? Photo { get; set; }

        public Guid OwnerId { get; set; }
        public User Owner { get; set; }

        public List<Contact> Contacts { get; set; }
        public List<Tour> Tours { get; set; } = new List<Tour>();
        
    }
}
