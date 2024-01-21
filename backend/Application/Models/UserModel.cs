using Domain.Enums;

namespace Application.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Patronymic { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public int? Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public bool IsActive { get; set; }
        public Role Role { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
