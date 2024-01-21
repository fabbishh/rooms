using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class GetSanatoriumProfileDataQuery : IRequest<SanatoriumProfileDataDto>
    {
        public Guid SanatoriumId { get; set; }
    }
}
