using Domain.Enums;

namespace webapi.DTO.Reservation
{
    public class UpdateReservationStatusRequest
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
        public string Comment { get; set; }
    }
}
