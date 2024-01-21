using Application.Models;
using HousingReservation.Domain.Models;
using MediatR;

namespace Application.Queries
{
    public class GetTourAgenciesTableDataQuery : IRequest<PagedResult<TourAgencyTableRow>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
