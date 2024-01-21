using Application.Extensions;
using Application.Models;
using Application.Queries;
using Domain.Common;
using HousingReservation.Domain.Entities;
using MediatR;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Linq.Expressions;

namespace Application.Handlers.Promo
{
    internal class GetPromoRequestsQueryHandler : IRequestHandler<GetPromoRequestsQuery, List<PromoInfo>>
    {
        private readonly IPromoRowItemRepository _promoRowItemRepository;
        private readonly IPromoBlockItemRepository _promoBlockItemRepository;
        public GetPromoRequestsQueryHandler(IPromoRowItemRepository promoRowItemRepository, IPromoBlockItemRepository promoBlockItemRepository)
        {
            _promoRowItemRepository = promoRowItemRepository;
            _promoBlockItemRepository = promoBlockItemRepository;
        }
        public async Task<List<PromoInfo>> Handle(GetPromoRequestsQuery request, CancellationToken cancellationToken)
        {
            var promoRowInfo = await GetPromoRowInfo(request.SanatoriumId);

            var promoBlocksInfo = await GetPromoBlocksInfo(request);

            var allPromo = promoRowInfo.Concat(promoBlocksInfo).ToList();

            return allPromo;
        }

        private async Task<List<PromoInfo>>  GetPromoBlocksInfo(GetPromoRequestsQuery request)
        {
            Expression<Func<PromoBlockItem, bool>>? filter = null;

            if (request.SanatoriumId is not null)
            {
                Expression<Func<PromoBlockItem, bool>> sanatoriumFilter = i => i.SanatoriumId == request.SanatoriumId;
                filter = filter == null
                    ? sanatoriumFilter
                    : filter.And(sanatoriumFilter);
            }
            if (request.TourAgencyId is not null)
            {
                Expression<Func<PromoBlockItem, bool>> tourAgencyFilter = i => i.TourAgencyId == request.TourAgencyId;
                filter = filter == null
                    ? tourAgencyFilter
                    : filter.And(tourAgencyFilter);
            }
            if (request.RoomId is not null)
            {
                Expression<Func<PromoBlockItem, bool>> roomFilter = i => i.RoomId == request.RoomId;
                filter = filter == null
                    ? roomFilter
                    : filter.And(roomFilter);
            }
            if (request.TourId is not null)
            {
                Expression<Func<PromoBlockItem, bool>> tourFilter = i => i.TourId == request.TourId;
                filter = filter == null
                    ? tourFilter
                    : filter.And(tourFilter);
            }

            if(filter is null)
            {
                return new List<PromoInfo>(0);
            }

            var promoBlockRequests = await _promoBlockItemRepository.FindAsync(filter);

            var promoBlocksInfo = promoBlockRequests.Select(r => new PromoInfo
            {
                Id = r.Id,
                Name = r.PromoBlock.Name,
                StartDate = r.DateAccepted,
                EndDate = r.DateCanceled,
                Status = r.AdminRequestStatus,
                PromoType = Domain.Enums.PromoType.Block
            }).ToList();

            return promoBlocksInfo;
        }

        private async Task<List<PromoInfo>> GetPromoRowInfo(Guid? sanatoriumId)
        {
            if(!sanatoriumId.HasValue)
            {
                return new List<PromoInfo>(0);
            }

            Expression<Func<PromoRowItem, bool>> sanatoriumFilter = i => i.SanatoriumId == sanatoriumId;

            var promoRowRequests = await _promoRowItemRepository.FindAsync(sanatoriumFilter);

            var promoRowInfo = promoRowRequests.Select(r => new PromoInfo
            {
                Id = r.Id,
                Name = "Промо ряд - " + r.PromoRowPlan.Name,
                StartDate = r.DateAccepted,
                EndDate = r.DateCanceled,
                Status = r.AdminRequestStatus,
                PromoType = Domain.Enums.PromoType.Row
            }).ToList();

            return promoRowInfo;
        }
    }
}
