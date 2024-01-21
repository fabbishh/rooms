using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class GetSanatoriumQuery : IRequest<SanatoriumDetailsDto>
    {
        public Guid Id { get; set; }
    }
}
