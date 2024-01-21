namespace webapi.DTO.Contacts
{
    public class AddContactsRequest
    {
        public Guid? SanatoriumId { get; set; }
        public Guid? TourAgencyId { get; set; }
        public List<ContactRequest> Contacts { get; set; }
    }
}
