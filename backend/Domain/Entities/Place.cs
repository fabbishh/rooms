using Domain.Common;
using Domain.Entities;
using HousingReservation.Domain.Common;

namespace HousingReservation.Domain.Entities
{
    public class Place : BaseEntity, IHasPhoto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
        public List<Photo> Photos { get; set; } = new List<Photo>();
        public List<SanatoriumPlace> SanatoriumPlaces { get; set; } = new List<SanatoriumPlace>();

    }
}
