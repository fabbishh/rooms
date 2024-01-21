using Domain.Entities;
using Domain.Enums;
using HousingReservation.Domain.Common;

namespace HousingReservation.Domain.Entities
{
    public class User : BaseEntity
    {
        public string? Login { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Patronymic { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool IsPhoneNumberConfirmed { get; set; }
        public UserGender? Gender { get; set; }
        public Role Role { get; set; }
        public List<UserRefreshToken> RefreshTokens { get; set; } = new List<UserRefreshToken>();
        public List<UserCode> Codes { get; set; } = new List<UserCode>();
        public List<FavouriteSanatorium> Favourites { get; set; } = new List<FavouriteSanatorium>();
    }
}
