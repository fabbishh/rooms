using Application.Models;
using Application.Queries;
using Domain.Common;
using MediatR;

namespace Application.Handlers
{
    public class GetSanatoriumContactsQueryHandler : IRequestHandler<GetSanatoriumContactsQuery, List<ContactDto>>
    {
        private readonly IContactRepository _contactRepository;

        public GetSanatoriumContactsQueryHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<List<ContactDto>> Handle(GetSanatoriumContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _contactRepository.FindAsync(c => c.SanatoriumId == request.SanatoriumId);

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
