using Application.Commands;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers
{
    internal class UpdateContactsCommandHandler : IRequestHandler<UpdateContactsCommand>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateContactsCommandHandler> _logger;
        public UpdateContactsCommandHandler(IContactRepository contactRepository, IUnitOfWork unitOfWork, ILogger<UpdateContactsCommandHandler> logger)
        {
            _contactRepository = contactRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task Handle(UpdateContactsCommand request, CancellationToken cancellationToken)
        {
            if (!request.SanatoriumId.HasValue && !request.TourAgencyId.HasValue || request.SanatoriumId.HasValue && request.TourAgencyId.HasValue)
            {
                throw new InvalidOperationException();
            }

            IEnumerable<Contact> existingContacts = null;

            if (request.SanatoriumId.HasValue)
            {
                existingContacts = await _contactRepository.FindAsync(c => c.SanatoriumId == request.SanatoriumId);
            }

            if (request.TourAgencyId.HasValue)
            {
                existingContacts = await _contactRepository.FindAsync(c => c.TourAgencyId == request.TourAgencyId);
            }

            var contactsToUpdate = request.Contacts.Where(c => c.Id.HasValue);

            var contactsToDelete = existingContacts!.Where(existing => !contactsToUpdate.Any(rc => rc.Id == existing.Id));

            foreach (var contact in contactsToDelete)
            {
                _contactRepository.Remove(contact);
            }

            foreach (var contact in contactsToUpdate)
            {
                var contactToUpdate = await _contactRepository.GetByIdAsync(contact.Id!.Value);
                if (contactToUpdate != null)
                {
                    contactToUpdate.Name = contact.Name;
                    contactToUpdate.PhoneNumber = contact.PhoneNumber;
                    _contactRepository.Update(contactToUpdate);
                }
            }

            var contactsToAdd = request.Contacts.Where(c => !c.Id.HasValue);

            foreach (var contact in contactsToAdd)
            {
                await _contactRepository.AddAsync(new Contact
                {
                    Id = Guid.NewGuid(),
                    Name = contact.Name,
                    PhoneNumber = contact.PhoneNumber,
                    SanatoriumId = request.SanatoriumId,
                    TourAgencyId = request.TourAgencyId,
                });
            }

            await _unitOfWork.SaveAsync();
            if(request.TourAgencyId.HasValue)
            {
                _logger.LogInformation("Контакты турагенства {@tourAgencyId} были обновлены", request.TourAgencyId);
            }
            if (request.SanatoriumId.HasValue)
            {
                _logger.LogInformation("Контакты санатория {@sanatoriumId} были обновлены", request.SanatoriumId);
            }
        }
    }
}
