using Application.Extensions;
using Application.Models;
using Application.Queries;
using Domain.Common;
using Domain.Enums;
using HousingReservation.Domain.Entities;
using MediatR;
using System.Linq.Expressions;

namespace Application.Handlers.Promo
{
    internal class GetPromoBlocksInfoQueryHandler : IRequestHandler<GetPromoBlocksInfoQuery, List<PromoInfo>>
    {
        private readonly IPromoBlockItemRepository _repository;

        public GetPromoBlocksInfoQueryHandler(IPromoBlockItemRepository promoBlockItemRepository)
        {
            _repository = promoBlockItemRepository;
        }
        public async Task<List<PromoInfo>> Handle(GetPromoBlocksInfoQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<PromoBlockItem, bool>>? filter = i => 
                i.SanatoriumId == request.SanatoriumId 
                && i.DateCanceled != null 
                && i.DateCanceled >= DateTimeOffset.UtcNow 
                && i.AdminRequestStatus == AdminRequestStatus.Confirmed;

            if (request.SanatoriumId is not null)
            {
                Expression<Func<PromoBlockItem, bool>> sanatoriumFilter = i => i.SanatoriumId == request.SanatoriumId;
                filter = filter.And(sanatoriumFilter);
            }
            else if (request.TourAgencyId is not null)
            {
                Expression<Func<PromoBlockItem, bool>> tourAgencyFilter = i => i.TourAgencyId == request.TourAgencyId;
                filter = filter.And(tourAgencyFilter);
            }
            else if (request.RoomId is not null)
            {
                Expression<Func<PromoBlockItem, bool>> roomFilter = i => i.RoomId == request.RoomId;
                filter = filter.And(roomFilter);
            }
            else if (request.TourId is not null)
            {
                Expression<Func<PromoBlockItem, bool>> tourFilter = i => i.TourId == request.TourId;
                filter = filter.And(tourFilter);
            }

            var blockItems = await _repository.FindAsync(filter);

            var promoInfo = blockItems.Select(p => new PromoInfo
            {
                Id = p.Id,
                Name = p.PromoBlock?.Name,
                StartDate = p.DateAccepted,
                EndDate = p.DateCanceled,
                PromoType = Domain.Enums.PromoType.Block
            }).OrderBy(p => p.Name).ToList();

            return promoInfo;
        }
    }
}
