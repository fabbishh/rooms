using Domain.Enums;
using MediatR;

namespace Application.Commands
{
    public class UpdateReservationStatusCommand : IRequest
    {
        public Guid Id { get; set; }
        public AdminRequestStatus Status { get; set; }
        public string Comment { get; set; }
    }
}
