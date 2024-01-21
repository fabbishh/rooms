using Domain.Enums;

namespace Application.Models
{
    public class ReservationDetailsModel
    {
        public Guid Id { get; set; }
        public AuthorModel? Author { get; set; }
        public string? RoomName { get; set; }
        public List<GuestModel> Guests { get; set; } = new List<GuestModel>();
        public AdminRequestStatus? Status { get; set; }
        public string? GuestComment { get; set; }
        public string? SanatoriumAdminComment {  get; set; }
    }
}
