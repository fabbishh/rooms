using HousingReservation.Domain.Common;
using HousingReservation.Domain.Entities;

namespace Domain.Entities
{
    public class UserCode : BaseEntity
    {
        public string Code { get; set; }
        public DateTimeOffset Expires { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
