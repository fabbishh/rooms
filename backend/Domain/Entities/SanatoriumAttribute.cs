using Domain.Common;
using HousingReservation.Domain.Common;

namespace HousingReservation.Domain.Entities
{
    public class SanatoriumAttribute : BaseEntity, IEntityAttribute
    {
        public Guid SanatoriumId { get; set; }
        public Sanatorium Sanatorium { get; set; }

        public Guid AttributeId { get; set; }
        public Attribute Attribute { get; set; }
    }
}
