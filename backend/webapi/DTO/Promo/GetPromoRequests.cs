namespace webapi.DTO.Promo
{
    public class GetPromoRequests
    {
        public Guid? SanatoriumId { get; set; }
        public Guid? RoomId { get; set; }
        public Guid? TourAgencyId { get; set; }
        public Guid? TourId { get; set; }
    }
}
