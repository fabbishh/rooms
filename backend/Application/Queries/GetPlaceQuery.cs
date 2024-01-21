using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class GetPlaceQuery : IRequest<PlaceDto>
    {
        public Guid PlaceId { get; set; }
    }
}
