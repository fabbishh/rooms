using Domain.Enums;
using HousingReservation.Domain.Common;

namespace HousingReservation.Domain.Entities
{
    public class PromoBlockItem : BaseEntity
    {
        public int Days { get; set; }
        public DateTimeOffset? DateAccepted { get; set; }
        public DateTimeOffset? DateCanceled { get; set; }
        public AdminRequestStatus AdminRequestStatus { get; set; }
        public Guid PromoBlockId { get; set; }
        public PromoBlock PromoBlock { get; set; }

        public Guid? SanatoriumId { get; set; }
        public Sanatorium? Sanatorium { get; set; }

        public Guid? RoomId { get; set; }
        public Room? Room { get; set; }

        public Guid? TourAgencyId { get; set; }
        public TourAgency? TourAgency { get; set; }

        public Guid? TourId { get; set; }
        public Tour? Tour { get; set; }
    }
}
