using MediatR;

namespace Application.Commands
{
    public class SaveSanatoriumDescriptionCommand : IRequest
    {
        public Guid SanatoriumId { get; set; }
        public string Description { get; set; }
    }
}
