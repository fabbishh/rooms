using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class GetPromoBlocksPricesQuery : IRequest<List<PromoBlockPriceInfo>>
    {
    }
}
