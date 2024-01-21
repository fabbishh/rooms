namespace webapi.DTO.Reservation
{
    public class ReservationFilter : BaseFilter
    {
        public Guid? SanatoriumId { get; set; }
        public Guid? UserId { get; set; }
        public bool? Activity {  get; set; }
        public int[]? Statuses { get; set; }
    }
}
