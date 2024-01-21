using Application.Models;
using Application.Queries;
using AutoMapper;
using Domain.Common;
using HousingReservation.Domain.Entities;
using MediatR;

namespace Application.Handlers
{
    public class GetPromoRowItemsQueryHandler : IRequestHandler<GetPromoRowItemsQuery, List<PromoRowItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPromoRowItemRepository _promoRowItemRepository;
        public GetPromoRowItemsQueryHandler(IMapper mapper, IPromoRowItemRepository promoRowItemRepository)
        {
            _mapper = mapper;
            _promoRowItemRepository = promoRowItemRepository;
        }
        public async Task<List<PromoRowItemDto>> Handle(GetPromoRowItemsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<PromoRowItem> items = null;
            if(request.Region is not null)
            {
                items = await _promoRowItemRepository.FindAsync(ri => ri.Sanatorium.SubjectId == request.Region && ri.AdminRequestStatus == Domain.Enums.AdminRequestStatus.Confirmed && ri.DateCanceled >= DateTimeOffset.UtcNow);
            } else
            {
                items = await _promoRowItemRepository.FindAsync(ri => ri.AdminRequestStatus == Domain.Enums.AdminRequestStatus.Confirmed && ri.DateCanceled >= DateTimeOffset.UtcNow);
            }

            var mappedItems = items.Select(i => new PromoRowItemDto
            {
                Id = i.Id,
                SanatoriumId = i.SanatoriumId,
                Location = i.Sanatorium.Location,
                MaxPrice = i.Sanatorium.RoomGroups.OrderByDescending(r => r.PricePerNight).FirstOrDefault()?.PricePerNight,
                MinPrice = i.Sanatorium.RoomGroups.OrderBy(r => r.PricePerNight).FirstOrDefault()?.PricePerNight,
                Name = i.Sanatorium.Name,
                PhotoUrl = i.Sanatorium.Photo?.OriginalUrl,
                Season = i.Sanatorium.Season,
            }).ToList();

            return mappedItems;
        }
    }
}
