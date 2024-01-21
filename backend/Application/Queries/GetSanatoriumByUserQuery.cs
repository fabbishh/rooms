using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class GetSanatoriumByUserQuery : IRequest<SanatoriumProfileDataDto>
    {
        public Guid UserId { get; set; }
    }
}
