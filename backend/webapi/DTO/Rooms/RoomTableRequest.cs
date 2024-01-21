namespace webapi.DTO.Rooms
{
    public class RoomTableRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Guid? SanatoriumId { get; set; }
        public int? HousingType { get; set; }
    }
}
