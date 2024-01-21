namespace Domain.Common
{
    public interface IEntityAttribute
    {
        public Guid AttributeId { get; set; }
        public HousingReservation.Domain.Entities.Attribute Attribute { get; set; }
    }
}
