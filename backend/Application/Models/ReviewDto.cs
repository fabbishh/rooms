namespace Application.Models
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Content { get; set; }
        public int OverallRating { get; set; }
        public int StaffRating { get; set; }
        public int TherapyRating { get; set; }
        public int CleanlinessRating { get; set; }
        public int FoodRating { get; set; }
        public int LocationRating { get; set; }
        public int EntertainmentRating { get; set; }
    }
}
