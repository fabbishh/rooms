namespace Application.Models
{
    public class RoomFilterModel
    {
        public Guid? SanatoriumId { get; set; }
        public int? HousingType { get; set; }
        public Guid? RoomGroupId { get; set; }
    }
}
