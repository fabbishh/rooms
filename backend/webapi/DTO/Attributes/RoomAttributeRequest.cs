namespace webapi.DTO.Attributes
{
    public class RoomAttributeRequest
    {
        public Guid? RoomAttributeId { get; set; }
        public Guid AttributeId { get; set; }
        public bool IsActive { get; set; }
    }
}
