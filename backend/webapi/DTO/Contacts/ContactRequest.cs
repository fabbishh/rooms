namespace webapi.DTO.Contacts
{
    public class ContactRequest
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
