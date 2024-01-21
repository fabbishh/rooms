using HousingReservation.Domain.Common;

namespace HousingReservation.Domain.Entities
{
    public class Attribute : BaseEntity
    {
        public string? Name { get; set; }
        public string FriendlyName { get; set; }
        public Guid AttributeGroupId { get; set; }
        public AttributeGroup AttributeGroup { get; set; }
    }
}
