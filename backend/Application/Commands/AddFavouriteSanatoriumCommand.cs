using MediatR;

namespace Application.Commands
{
    public class AddFavouriteSanatoriumCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid SanatoriumId { get; set; }
    }
}
