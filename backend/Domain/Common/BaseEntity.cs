namespace HousingReservation.Domain.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public bool Deleted { get; set; }
    }
}
