using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class GetPromoRowPlansQuery : IRequest<List<PromoPlanModel>>
    {
    }
}
