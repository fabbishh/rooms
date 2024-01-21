namespace webapi.DTO.Sanatoriums
{
    public class SaveSanatoriumDescriptionRequest
    {
        public Guid SanatoriumId { get; set; }
        public string Description { get; set; }
    }
}
