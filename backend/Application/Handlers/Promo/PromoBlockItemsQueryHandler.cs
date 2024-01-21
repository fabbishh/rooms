using Application.Models;
using Domain.Common;
using FluentEmail.Core;
using MediatR;

namespace Application.Handlers.Promo
{
    internal class PromoBlockItemsQueryHandler : IRequestHandler<PromoBlockItemsQuery, List<PromoBlockItemModel>>
    {
        private readonly IPromoBlockItemRepository _repository;
        public PromoBlockItemsQueryHandler(IPromoBlockItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<PromoBlockItemModel>> Handle(PromoBlockItemsQuery request, CancellationToken cancellationToken)
        {
            var items = await _repository.FindAsync(r => r.PromoBlockId == request.PromoBlockId && r.AdminRequestStatus == Domain.Enums.AdminRequestStatus.Confirmed && r.DateCanceled >= DateTimeOffset.UtcNow);

            var mappedItems = new List<PromoBlockItemModel>();

            items.ForEach(i =>
            {
                if (i.SanatoriumId.HasValue)
                {
                    mappedItems.Add(new PromoBlockItemModel
                    {
                        PromoBlockItemId = i.Id,
                        SanatoriumId = i.SanatoriumId.Value,
                        Description = "",
                        Name = i.Sanatorium!.Name,
                        PhotoUrl = i.Sanatorium?.Photo?.OriginalUrl,
                    });
                }
                else if (i.RoomId.HasValue)
                {
                    mappedItems.Add(new PromoBlockItemModel
                    {
                        PromoBlockItemId = i.Id,
                        RoomId = i.RoomId.Value,
                        Description = i.Room!.Group.Description,
                        Name = $"{i.Room.Group.Name} {i.Room!.Name}",
                        PhotoUrl = i.Room?.Group?.Photos?.FirstOrDefault()?.OriginalUrl,
                    });
                }
                else if (i.TourAgencyId.HasValue)
                {
                    mappedItems.Add(new PromoBlockItemModel
                    {
                        PromoBlockItemId = i.Id,
                        TourAgencyId = i.TourAgencyId.Value,
                        Description = i.TourAgency!.Description,
                        Name = i.TourAgency!.Name,
                        PhotoUrl = i.TourAgency?.Photo?.OriginalUrl,
                    });
                }
                else if (i.TourId.HasValue)
                {
                    mappedItems.Add(new PromoBlockItemModel
                    {
                        PromoBlockItemId = i.Id,
                        SanatoriumId = i.TourId.Value,
                        Description = i.Tour!.Description,
                        Name = i.Tour!.Name,
                        PhotoUrl = i.Tour?.Photos?.FirstOrDefault()?.OriginalUrl,
                    });
                }
            });

            return mappedItems;
        }
    }
}
