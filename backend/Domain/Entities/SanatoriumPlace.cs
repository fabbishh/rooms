using HousingReservation.Domain.Common;

namespace HousingReservation.Domain.Entities
{
    public class SanatoriumPlace : BaseEntity
    {
        public Guid PlaceId { get; set; }
        public Place Place { get; set; }
        public Guid SanatoriumId { get; set; }
        public Sanatorium Sanatorium { get; set; }
    }
}
