using HousingReservation.Domain.Entities;

namespace webapi.DTO.Reservation
{
    public class CreateAuthorizedReservationRequest
    {
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }

        public int AdultGuestsCount { get; set; }
        public int ChildGuestsCount { get; set; }

        public Guid? UserId { get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string Patronymic {  get; set; }
        public string Phone {  get; set; }

        public string? GuestComment { get; set; }

        public bool IsAuthorGuest { get; set; }

        public Guid RoomId { get; set; }
        public List<GuestDto>? Guests { get; set; }

    }
}
