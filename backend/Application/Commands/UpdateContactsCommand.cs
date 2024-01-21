using Application.Models;
using MediatR;

namespace Application.Commands
{
    public class UpdateContactsCommand : IRequest
    {
        public Guid? SanatoriumId { get; set; }
        public Guid? TourAgencyId { get; set; }
        public List<ContactDto> Contacts { get; set; }
    }
}
