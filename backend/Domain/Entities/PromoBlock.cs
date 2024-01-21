using HousingReservation.Domain.Common;

namespace HousingReservation.Domain.Entities
{
    public class PromoBlock : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<PromoBlockItem> PromoBlockItems { get; set; } = new List<PromoBlockItem>();
    }
}
