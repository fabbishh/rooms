namespace webapi.DTO.Users
{
    public class SaveUserRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Patronymic { get; set; }
        public string? Phone { get; set; }
        public DateTime Birthday { get; set; }
        public int Gender { get; set; }
    }
}
