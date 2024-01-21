using Application.Models;
using HousingReservation.Domain.Models;
using MediatR;

namespace Application.Queries
{
    public class FavouriteSanatoriumsQuery : IRequest<PagedResult<SanatoriumDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Guid UserId { get; set; }
    }
}
