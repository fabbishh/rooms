namespace webapi.DTO.Tours
{
    public class SaveTourDateRequest
    {
        public Guid? Id { get; set; }
        public DateTimeOffset StartDate { get; set; }
    }
}
