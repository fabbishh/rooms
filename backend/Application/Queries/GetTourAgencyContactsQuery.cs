using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class GetTourAgencyContactsQuery : IRequest<List<ContactDto>>
    {
        public Guid TourAgencyId { get; set; }
    }
}
