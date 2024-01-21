using Application.Commands;
using Application.Exceptions;
using Domain.Common;
using Domain.Enums;
using HousingReservation.Domain.Entities;
using HousingReservation.Domain.Sanatoriums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers
{
    public class CreatePromoRowItemCommandHandler : IRequestHandler<CreatePromoRowItemCommand>
    {
        private readonly ISanatoriumRepository _sanatoriumRepository;
        private readonly IPromoRowItemRepository _promoRowItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreatePromoRowItemCommandHandler> _logger;

        public CreatePromoRowItemCommandHandler(
            ISanatoriumRepository sanatoriumRepository, 
            IPromoRowItemRepository promoRowItemRepository, 
            IUnitOfWork unitOfWork,
            ILogger<CreatePromoRowItemCommandHandler> logger)
        {
            _promoRowItemRepository = promoRowItemRepository;
            _sanatoriumRepository = sanatoriumRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Handle(CreatePromoRowItemCommand request, CancellationToken cancellationToken)
        {
            var existingSanatorium = await _sanatoriumRepository.GetByIdAsync(request.SanatoriumId);
            if (existingSanatorium == null)
            {
                throw new SanatoriumNotFoundException(request.SanatoriumId);
            }

            var sanatoriumInPromo = await _promoRowItemRepository.FindAsync(pri => pri.SanatoriumId == request.SanatoriumId);
            if (sanatoriumInPromo.Any())
            {
                throw new SanatoriumHasPromotionException(request.SanatoriumId);
            }

            var promoItem = new PromoRowItem
            {
                Id = Guid.NewGuid(),
                AdminRequestStatus = AdminRequestStatus.Pending,
                DateAccepted = null,
                DateCanceled = null,
                PromoRowPlanId = request.PlanId,
                DateCreated = DateTimeOffset.UtcNow,
                SanatoriumId = existingSanatorium.Id,
            };

            await _promoRowItemRepository.AddAsync(promoItem);
            await _unitOfWork.SaveAsync();
            _logger.LogInformation("Запрос на добавление санатория {@id} в проморяд", request.SanatoriumId);
        }
    }
}
