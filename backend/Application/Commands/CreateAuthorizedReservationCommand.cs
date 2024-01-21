using Application.Models;
using MediatR;

namespace Application.Commands
{
    public class CreateAuthorizedReservationCommand : IRequest
    {
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public int AdultGuestsCount { get; set; }
        public int ChildGuestsCount { get; set; }
        public string? GuestComment { get; set; }

        public Guid RoomId { get; set; }

        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }

        public List<GuestModel>? Guests { get; set; }
    }
}
