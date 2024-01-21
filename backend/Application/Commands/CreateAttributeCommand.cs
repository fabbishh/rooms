using MediatR;

namespace Application.Commands
{
    public class CreateAttributeCommand : IRequest
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Guid AttributeGroupId { get; set; }
        public int EntityType { get; set; }
    }
}
