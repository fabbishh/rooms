namespace HousingReservation.Domain.Models.Auth
{
    public record RegistrationModel
    {
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
    }
}
