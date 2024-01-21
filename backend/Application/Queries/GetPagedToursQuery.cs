using Application.Models;
using HousingReservation.Domain.Models;
using MediatR;

namespace Application.Queries
{
    public class GetPagedToursQuery : IRequest<PagedResult<PagedToursItem>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public TourFilterModel? Filter { get; set; }
    }
}
