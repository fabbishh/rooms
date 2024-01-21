using Domain.Common;
using Domain.Entities;
using Domain.Enums;
using HousingReservation.Domain.Common;

namespace HousingReservation.Domain.Entities
{
    public class Sanatorium : BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string CheckInTime { get; set; }
        public string CheckOutTime { get; set; }
        public string? Description { get; set; }
        public SanatoriumSeason Season { get; set; }
        public AdminRequestStatus Status { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        public Guid TypeId { get; set; }
        public SanatoriumType Type { get; set; }

        public Guid OwnerId { get; set; }
        public User Owner { get; set; }

        public Guid? PhotoId { get; set; }
        public Photo? Photo { get; set; }

        public List<RoomGroup> RoomGroups { get; set; } = new List<RoomGroup>();
        public List<SanatoriumAttribute> SanatoriumAttributes { get; set; } = new List<SanatoriumAttribute>();
        public List<SanatoriumPlace> SanatoriumPlaces { get; set; } = new List<SanatoriumPlace>();
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<Contact> Contacts { get; set; } = new List<Contact>();
        public List<PromoRowItem> PromoRowItems { get; set; } = new List<PromoRowItem>();
        public List<FavouriteSanatorium> Favourites { get; set; } = new List<FavouriteSanatorium>();
    }
}
