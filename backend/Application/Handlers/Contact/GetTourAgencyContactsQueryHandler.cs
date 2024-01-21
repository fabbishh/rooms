using Application.Models;
using Application.Queries;
using Domain.Common;
using MediatR;

namespace Application.Handlers
{
    public class GetTourAgencyContactsQueryHandler : IRequestHandler<GetTourAgencyContactsQuery, List<ContactDto>>
    {
        private readonly IContactRepository _contactRepository;
        public GetTourAgencyContactsQueryHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<List<ContactDto>> Handle(GetTourAgencyContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _contactRepository.FindAsync(c => c.TourAgencyId == request.TourAgencyId);

            var mappedContacts = contacts.Select(c => new ContactDto
            {
                Id = c.Id,
                Name = c.Name,
                PhoneNumber = c.PhoneNumber,
            }).ToList();

            return mappedContacts;
        }
    }
}
