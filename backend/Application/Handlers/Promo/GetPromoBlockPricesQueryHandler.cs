using Application.Models;
using Application.Queries;
using Domain.Common;
using MediatR;

namespace Application.Handlers.Promo
{
    internal class GetPromoBlockPricesQueryHandler : IRequestHandler<GetPromoBlocksPricesQuery, List<PromoBlockPriceInfo>>
    {
        private readonly IPromoBlockRepository _repository;
        public GetPromoBlockPricesQueryHandler(IPromoBlockRepository promoBlockRepository)
        {
            _repository = promoBlockRepository;
        }
        public async Task<List<PromoBlockPriceInfo>> Handle(GetPromoBlocksPricesQuery request, CancellationToken cancellationToken)
        {
            var blocks = await _repository.GetAllAsync();

            var mappedBlocks = blocks.Select(b => new PromoBlockPriceInfo
            {
                Id = b.Id,
                Name = b.Name,
                Price = b.Price,
            }).OrderBy(b => b.Name);

            return mappedBlocks.ToList();
        }
    }
}
