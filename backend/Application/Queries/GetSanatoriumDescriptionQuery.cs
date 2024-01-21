using MediatR;

namespace Application.Queries
{
    public class GetSanatoriumDescriptionQuery : IRequest<string?>
    {
        public Guid SanatoriumId { get; set; }
    }
}
