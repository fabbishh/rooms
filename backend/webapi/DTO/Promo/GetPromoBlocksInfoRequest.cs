namespace webapi.DTO.Promo
{
    public class GetPromoBlocksInfoRequest
    {
        public Guid? SanatoriumId { get; set; }
        public Guid? RoomId { get; set; }
        public Guid? TourAgencyId { get; set; }
        public Guid? TourId { get; set; }
    }
}
