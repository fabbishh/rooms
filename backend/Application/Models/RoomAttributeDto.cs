namespace Application.Models
{
    public class RoomAttributeDto
    {
        public Guid? RoomAttributeId { get; set; }
        public Guid AttributeId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
