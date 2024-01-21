namespace Application.Models
{
    public class RoomAttributeModel
    {
        public Guid RoomAttributeId { get; set; }
        public string Name { get; set; }
        public string? GroupName { get; set; }
        public bool IsActive { get; set; }
    }
}
