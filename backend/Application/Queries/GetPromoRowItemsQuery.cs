using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class GetPromoRowItemsQuery : IRequest<List<PromoRowItemDto>>
    {
        public Guid? Region {  get; set; }
    }
}
