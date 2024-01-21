using Application.Models;
using Application.Queries;
using Domain.Common;
using MediatR;

namespace Application.Handlers.Promo
{
    internal class GetPromoRowInfoQueryHandler : IRequestHandler<GetPromoRowInfoQuery, PromoInfo>
    {
        private readonly IPromoRowItemRepository _repository;
        public GetPromoRowInfoQueryHandler(IPromoRowItemRepository promoRowItemRepository)
        {
            _repository = promoRowItemRepository;
        }
        public async Task<PromoInfo> Handle(GetPromoRowInfoQuery request, CancellationToken cancellationToken)
        {
            var promoRowItem = await _repository.FindOneAsync(i => 
                            i.SanatoriumId == request.SanatoriumId 
                            && i.DateCanceled != null 
                            && i.DateCanceled >= DateTimeOffset.UtcNow 
                            && i.AdminRequestStatus == Domain.Enums.AdminRequestStatus.Confirmed);
            if (promoRowItem is null)
            {
                return null;
            }

            var promoInfo = new PromoInfo
            {
                Id = promoRowItem.Id,
                Name = promoRowItem.PromoRowPlan!.Name,
                StartDate = promoRowItem.DateAccepted,
                EndDate = promoRowItem.DateCanceled,
                PromoType = Domain.Enums.PromoType.Row
            };

            return promoInfo;
        }
    }
}
