using MediatR;

namespace Application.Commands
{
    public class DeleteUsersCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
    }
}
