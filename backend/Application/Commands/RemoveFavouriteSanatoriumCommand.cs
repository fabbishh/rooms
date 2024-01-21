using MediatR;

namespace Application.Commands
{
    public class RemoveFavouriteSanatoriumCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid SanatoriumId { get; set; }
    }
}
