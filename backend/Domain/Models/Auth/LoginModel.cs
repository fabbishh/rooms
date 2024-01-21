namespace HousingReservation.Domain.Models.Auth
{
    public record LoginModel
    {
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
    }
}
