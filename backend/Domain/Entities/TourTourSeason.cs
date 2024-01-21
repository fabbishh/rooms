using HousingReservation.Domain.Common;
using HousingReservation.Domain.Entities;

namespace Domain.Entities
{
    public class TourTourSeason : BaseEntity
    {
        public Guid TourId { get; set; }
        public Tour Tour { get; set; }
        public Guid TourSeasonId { get; set; }
        public HousingReservation.Domain.Entities.TourSeason TourSeason { get; set; }
    }
}
