using Domain.Entities;
using Domain.Enums;
using HousingReservation.Domain.Common;

namespace HousingReservation.Domain.Entities
{
    public class PromoRowItem : BaseEntity
    {
        public int Days { get; set; }
        public Guid SanatoriumId { get; set; } 
        public Sanatorium Sanatorium { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset? DateAccepted { get; set; }
        public DateTimeOffset? DateCanceled { get; set; }
        public AdminRequestStatus AdminRequestStatus { get; set; }
        public Guid PromoRowPlanId { get; set; }
        public PromoRowPlan PromoRowPlan { get; set; }
    }
}
