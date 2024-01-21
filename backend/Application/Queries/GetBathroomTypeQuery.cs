using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class GetBathroomTypeQuery : IRequest<List<BathroomTypeDto>>
    {
    }
}
