using MediatR;

namespace Application.Commands
{
    public class CreateTourTypeCommand : IRequest
    {
        public string Name { get; set; }
    }
}
