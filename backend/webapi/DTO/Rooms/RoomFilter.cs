namespace webapi.DTO.Rooms
{
    public class RoomFilter : BaseFilter
    {
        public Guid? SanatoriumId { get; set; }
        public int? HousingType { get; set; }
        public Guid? RoomGroupId { get; set; }
    }
}
