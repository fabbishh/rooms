using Domain.Entities;
using Domain.Enums;
using HousingReservation.Domain.Common;

namespace HousingReservation.Domain.Entities
{
    public class Tour : BaseEntity
    {
        public string Name { get; set; }
        public List<TourDate> TourDates { get; set; }
        public decimal? PriceByTourist { get; set; }
        public decimal? PriceByGroup { get; set; }
        public int Days { get; set; }
        public int TouristCountFrom { get; set; }
        public int TouristCountTo { get; set; }
        public string Description { get; set; }
        public Guid TourAgencyId { get; set; }
        public AdminRequestStatus Status { get; set; }

        public Guid TypeId { get; set; }
        public TourType Type { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        public TourAgency TourAgency { get; set; }
        public List<Photo> Photos { get; set; } = new List<Photo>();
        public List<TourTourSeason> Seasons { get; set; } = new List<TourTourSeason>();
        public List<TourReview> Reviews { get; set; } = new List<TourReview>();
    }
}
