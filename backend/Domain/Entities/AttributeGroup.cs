using HousingReservation.Domain.Common;

namespace HousingReservation.Domain.Entities
{
    public class AttributeGroup : BaseEntity
    {
        public string Name { get; set; }
        public string FriendlyName { get; set; }
        public List<Attribute> Attributes { get; set; } = new List<Attribute>();
    }
}
