using Domain.Common;
using HousingReservation.Domain.Common;
using HousingReservation.Domain.Entities;

namespace HousingReservation.Domain.Entities
{
    public class RoomAttribute : BaseEntity, IEntityAttribute
    {
        public Guid RoomGroupId { get; set; }
        public RoomGroup RoomGroup { get; set; }
        public Guid AttributeId { get; set; }
        public HousingReservation.Domain.Entities.Attribute Attribute {  get; set; }
    }
}
