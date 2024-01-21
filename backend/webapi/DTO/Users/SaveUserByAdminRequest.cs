namespace webapi.DTO.Users
{
    public class SaveUserByAdminRequest : SaveUserRequest
    {
        public Guid? Id { get; set; }
        public int Role {  get; set; }
        public string Email { get; set; }
    }
}
