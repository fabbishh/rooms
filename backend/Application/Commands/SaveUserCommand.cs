using Domain.Enums;
using MediatR;

namespace Application.Commands
{
    public class SaveUserCommand : IRequest
    {
        public Guid? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Patronymic { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime Birthday { get; set; }
        public int Gender { get; set; }
        public Role Role { get; set; }
    }
}
