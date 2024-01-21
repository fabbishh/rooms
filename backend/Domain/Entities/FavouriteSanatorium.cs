using HousingReservation.Domain.Common;
using HousingReservation.Domain.Entities;

namespace Domain.Entities
{
    public class FavouriteSanatorium : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid SanatoriumId { get; set; }
        public Sanatorium Sanatorium { get; set; }
    }
}
