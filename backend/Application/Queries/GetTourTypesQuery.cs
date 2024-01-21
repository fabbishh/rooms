using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class GetTourTypesQuery : IRequest<List<TourTypeModel>>
    {
    }
}
