using MediatR;

namespace Application.Commands
{
    public class DeleteToursCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
    }
}
