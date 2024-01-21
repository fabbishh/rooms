using Domain.Enums;

namespace Application.Models
{
    public class PromoInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public AdminRequestStatus Status { get; set; }
        public PromoType PromoType { get; set; }
    }
}
