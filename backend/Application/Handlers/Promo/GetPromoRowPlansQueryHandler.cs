using Application.Models;
using Application.Queries;
using Domain.Common;
using MediatR;

namespace Application.Handlers.Promo
{
    internal class GetPromoRowPlansQueryHandler : IRequestHandler<GetPromoRowPlansQuery, List<PromoPlanModel>>
    {
        private readonly IPromoRowPlanRepository _promoRowPlanRepository;
        public GetPromoRowPlansQueryHandler(IPromoRowPlanRepository promoRowPlanRepository)
        {
            _promoRowPlanRepository = promoRowPlanRepository;
        }

        public async Task<List<PromoPlanModel>> Handle(GetPromoRowPlansQuery request, CancellationToken cancellationToken)
        {
            var plans = await _promoRowPlanRepository.GetAllAsync();

            var mappedPlans = plans.Select(p => new PromoPlanModel
            {
                Id = p.Id,
                Days = p.Days,
                Name = p.Name,
                Price = p.Price,
            }).OrderBy(p => p.Price);

            return mappedPlans.ToList();
        }
    }
}
