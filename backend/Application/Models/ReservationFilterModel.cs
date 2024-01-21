namespace Application.Models
{
    public class ReservationFilterModel
    {
        public Guid? SanatoriumId { get; set; }
        public Guid? UserId { get; set; }
        public bool? Activity { get; set; }
        public int[]? Statuses { get; set; }
    }
}
