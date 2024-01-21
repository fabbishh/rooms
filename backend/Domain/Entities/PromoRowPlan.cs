using HousingReservation.Domain.Common;
using HousingReservation.Domain.Entities;

namespace Domain.Entities
{
    public class PromoRowPlan : BaseEntity
    {
        public decimal Price { get; set; }
        public int Days { get; set; }
        public string Name {  get; set; }
        public List<PromoRowItem> PromoRowItems { get; set; }
    }
}
