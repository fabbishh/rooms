using Application.Models;
using HousingReservation.Domain.Models;
using MediatR;

namespace Application.Queries
{
    public class GetPagedToursTableDataQuery : IRequest<PagedResult<ToursTableRow>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public TourFilterModel Filter { get; set; }
    }
}
