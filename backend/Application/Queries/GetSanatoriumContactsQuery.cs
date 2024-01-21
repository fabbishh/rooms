using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class GetSanatoriumContactsQuery : IRequest<List<ContactDto>>
    {
        public Guid SanatoriumId { get; set; }
    }
}
