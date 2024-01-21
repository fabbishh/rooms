using Application.Commands;
using Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers
{
    internal class DeleteToursCommandHandler : IRequestHandler<DeleteToursCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteToursCommandHandler> _logger;
        private readonly ITourRepository _tourRepository;
        private readonly ITourDateRepository _tourDateRepository;
        private readonly ITourReviewRepository _tourReviewRepository;
        private readonly IPromoBlockItemRepository _promoBlockItemRepository;
        public DeleteToursCommandHandler(
            IUnitOfWork unitOfWork,
            ILogger<DeleteToursCommandHandler> logger,
            ITourRepository tourRepository,
            ITourDateRepository tourDateRepository,
            ITourReviewRepository tourReviewRepository,
            IPromoBlockItemRepository promoBlockItemRepository
            )
        {
            _tourRepository = tourRepository;
            _tourDateRepository = tourDateRepository;
            _tourReviewRepository = tourReviewRepository;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _promoBlockItemRepository = promoBlockItemRepository;
        }
        public async Task Handle(DeleteToursCommand request, CancellationToken cancellationToken)
        {
            var tours = await _tourRepository.FindAsync(t => request.Ids.Contains(t.Id));

            if (!tours.Any())
            {
                return;
            }

            foreach (var t in tours)
            {
                _tourRepository.SetDeletedFlag(t);
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

            var pbi = await _promoBlockItemRepository.FindAsync(r => r.TourId.HasValue && tours.Select(r => r.Id).Contains(r.TourId.Value));
            foreach (var item in pbi)
            {
                _promoBlockItemRepository.SetDeletedFlag(item);
            }

            await _unitOfWork.SaveAsync();
            _logger.LogInformation("Удалены туры: {@ids}", request.Ids);
        }
    }
}
