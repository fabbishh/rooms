using MediatR;

namespace Application.Commands
{
    public class DeleteAttributesCommand : IRequest
    {
        public List<Guid> AttributeIds { get; set; } = new List<Guid>();
    }
}
