using MediatR;

namespace Application.Commands
{
    public class CreateRoomReservationCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid RoomId { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public int GuestsCount { get; set; }
    }
}
