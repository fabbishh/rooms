using HousingReservation.Domain.Common;

namespace HousingReservation.Domain.Entities
{
    public class TourSeason : BaseEntity
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
