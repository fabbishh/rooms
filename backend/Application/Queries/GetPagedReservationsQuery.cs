using Application.Models;
using HousingReservation.Domain.Models;
using MediatR;

namespace Application.Queries
{
    public class GetPagedReservationsQuery : IRequest<PagedResult<ReservationsTableRow>?>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public ReservationFilterModel? Filter { get; set; }
    }
}
