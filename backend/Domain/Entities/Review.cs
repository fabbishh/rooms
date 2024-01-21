using Domain.Enums;
using HousingReservation.Domain.Common;

namespace HousingReservation.Domain.Entities
{
    public class Review : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
        public int OverallRating { get; set; }
        public int StaffRating { get; set; }
        public int CleanlinessRating { get; set; }
        public int TherapyRating {  get; set; }
        public int FoodRating { get; set; }
        public int LocationRating { get; set; }
        public int EntertainmentRating { get; set; }
        public AdminRequestStatus Status { get; set; }
        public Guid SanatoriumId { get; set; }
        public Sanatorium Sanatorium { get; set; }
    }
}
