using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class GetMealTypeQuery : IRequest<List<MealTypeDto>>
    {
    }
}
