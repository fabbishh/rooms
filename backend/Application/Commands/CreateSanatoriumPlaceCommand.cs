using MediatR;

namespace Application.Commands
{
    public class CreateSanatoriumPlaceCommand : IRequest
    {
        public Guid PlaceId { get; set; }
        public Guid SanatoriumId { get; set; }
    }
}
