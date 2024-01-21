using MediatR;

namespace Application.Commands
{
    public class DeleteRoomGroupsCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
    }
}
