using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class GetReservationQuery : IRequest<ReservationDetailsModel?>
    {
        public Guid ReservationId { get; set; }
    }
}
