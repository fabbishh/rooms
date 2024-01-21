using MediatR;

namespace Application.Commands
{
    public class CreateSanatoriumTypeCommand : IRequest
    {
        public string Name { get; init; }
    }
}
