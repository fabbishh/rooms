using Application.Commands;
using Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers.Promo
{
    internal class ChangePromoStatusCommandHandler : IRequestHandler<ChangePromoStatusCommand>
    {
        private readonly IPromoRowItemRepository _promoRowItemRepository;
        private readonly IPromoBlockItemRepository _blockItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ChangePromoStatusCommandHandler> _logger;

        public ChangePromoStatusCommandHandler
            (
                IPromoRowItemRepository promoRowItemRepository,
                IPromoBlockItemRepository blockItemRepository,
                ILogger<ChangePromoStatusCommandHandler> logger,
                IUnitOfWork unitOfWork
            )
        {
            _promoRowItemRepository = promoRowItemRepository;
            _blockItemRepository = blockItemRepository;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(ChangePromoStatusCommand request, CancellationToken cancellationToken)
        {
            if(request.PromoType == Domain.Enums.PromoType.Row)
            {
                var existingItem = await _promoRowItemRepository.GetByIdAsync(request.PromoId);
                if (existingItem is null)
                {
                    return;
                }

                existingItem.AdminRequestStatus = request.Status;
                if (request.Status == Domain.Enums.AdminRequestStatus.Confirmed)
                {
                    existingItem.DateAccepted = DateTimeOffset.UtcNow;
                    existingItem.DateCanceled = DateTimeOffset.UtcNow.AddDays(existingItem.PromoRowPlan.Days);
                }
                else if (request.Status == Domain.Enums.AdminRequestStatus.Declined)
                {
                    existingItem.DateCanceled = DateTimeOffset.UtcNow;
                }


                _promoRowItemRepository.Update(existingItem);
                await _unitOfWork.SaveAsync();

                _logger.LogInformation("Статус для промо {@promo} был изменен на {@status}", existingItem.Id, existingItem.AdminRequestStatus);
            }
            if(request.PromoType == Domain.Enums.PromoType.Block)
            {
                var existingItem = await _blockItemRepository.GetByIdAsync(request.PromoId);
                if (existingItem is null)
                {
                    return;
                }

                existingItem.AdminRequestStatus = request.Status;
                if (request.Status == Domain.Enums.AdminRequestStatus.Confirmed)
                {
                    existingItem.DateAccepted = DateTimeOffset.UtcNow;
                    existingItem.DateCanceled = DateTimeOffset.UtcNow.AddDays(30);
                }
                else if (request.Status == Domain.Enums.AdminRequestStatus.Declined)
                {
                    existingItem.DateCanceled = DateTimeOffset.UtcNow;
                }


                _blockItemRepository.Update(existingItem);
                await _unitOfWork.SaveAsync();

                _logger.LogInformation("Статус для промо {@promo} был изменен на {@status}", existingItem.Id, existingItem.AdminRequestStatus);
            }
        }
    }
}
