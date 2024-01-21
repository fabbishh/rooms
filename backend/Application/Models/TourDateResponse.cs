namespace Application.Models
{
    public class TourDateResponse
    {
        public Guid Id { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public int AvailableSlots { get; set; }
    }
}
