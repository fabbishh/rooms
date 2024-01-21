using Application.Commands;
using Domain.Common;
using HousingReservation.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    internal class DeleteTourAgencyCommandHandler : IRequestHandler<DeleteTourAgencyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteTourAgencyCommandHandler> _logger;
        private readonly ITourAgencyRepository _tourAgencyRepository;
        private readonly IContactRepository _contactRepository;
        private readonly ITourRepository _tourRepository;
        private readonly ITourDateRepository _tourDateRepository;
        private readonly ITourReviewRepository _tourReviewRepository;
        private readonly IPromoBlockItemRepository _promoBlockItemRepository;

        public DeleteTourAgencyCommandHandler(
            IUnitOfWork unitOfWork,
            ILogger<DeleteTourAgencyCommandHandler> logger,
            ITourAgencyRepository tourAgencyRepository,
            IContactRepository contactRepository,
            ITourRepository tourRepository,
            ITourDateRepository tourDateRepository,
            ITourReviewRepository tourReviewRepository,
            IPromoBlockItemRepository promoBlockItemRepository
            )
        {
            _contactRepository = contactRepository;
            _tourRepository = tourRepository;
            _tourDateRepository = tourDateRepository;
            _tourReviewRepository = tourReviewRepository;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _tourAgencyRepository = tourAgencyRepository;
            _promoBlockItemRepository = promoBlockItemRepository;
        }

        public async Task Handle(DeleteTourAgencyCommand request, CancellationToken cancellationToken)
        {
            var tourAgencies = await _tourAgencyRepository.FindAsync(s => request.Ids.Contains(s.Id));

            if (!tourAgencies.Any())
            {
                return;
            }

            foreach (var a in tourAgencies)
            {
                _tourAgencyRepository.SetDeletedFlag(a);
            }

            var pbitems = await _promoBlockItemRepository.FindAsync(r => r.TourAgencyId.HasValue && tourAgencies.Select(r => r.Id).Contains(r.TourAgencyId.Value));
            foreach (var item in pbitems)
            {
                _promoBlockItemRepository.SetDeletedFlag(item);
            }

            var contacts = await _contactRepository.FindAsync(c => c.TourAgencyId.HasValue && tourAgencies.Select(ta => ta.Id).Contains(c.TourAgencyId.Value));
            foreach (var contact in contacts)
            {
                _contactRepository.SetDeletedFlag(contact);
            }

            var tours = await _tourRepository.FindAsync(t => tourAgencies.Select(ta => ta.Id).Contains(t.TourAgencyId));
            foreach (var t in tours)
            {
                _tourRepository.SetDeletedFlag(t);
            }

            var pbi = await _promoBlockItemRepository.FindAsync(r => r.TourId.HasValue && tours.Select(r => r.Id).Contains(r.TourId.Value));
            foreach (var item in pbi)
            {
                _promoBlockItemRepository.SetDeletedFlag(item);
            }

            var reviews = await _tourReviewRepository.FindAsync(r => tours.Select(t => t.Id).Contains(r.TourId));
            foreach (var r in reviews)
            {
                _tourReviewRepository.SetDeletedFlag(r);
            }

            var dates = await _tourDateRepository.FindAsync(d => tours.Select(t => t.Id).Contains(d.TourId));
            foreach (var d in dates)
            {
                _tourDateRepository.SetDeletedFlag(d);
            }

            await _unitOfWork.SaveAsync();
            _logger.LogInformation("Удалены турагенства: {@ids}", request.Ids);
        }
    }
}
