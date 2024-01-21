using Application.Models;
using HousingReservation.Domain.Models;
using MediatR;

namespace Application.Queries
{
    public class GetSanatoriumsTableDataQuery : IRequest<PagedResult<SanatoriumTableRow>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
