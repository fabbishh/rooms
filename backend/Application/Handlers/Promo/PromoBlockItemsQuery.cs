using Application.Models;
using MediatR;

namespace Application.Handlers.Promo
{
    public class PromoBlockItemsQuery : IRequest<List<PromoBlockItemModel>>
    {
        public Guid PromoBlockId { get; set; }
    }
}
