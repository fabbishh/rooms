using MediatR;

namespace Application.Commands
{
    public class DeleteSanatoriumsCommand : IRequest
    {
        public List<Guid> Ids { get; init; }
    }
}
