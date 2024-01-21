using Application.Models;
using HousingReservation.Domain.Models;
using MediatR;

namespace Application.Queries
{
    public class GetPagedPlacesQuery : IRequest<PagedResult<PlaceDto>>
    {
        public string? SearchQuery { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Guid? SanatoriumId { get; set; }
    }
}
