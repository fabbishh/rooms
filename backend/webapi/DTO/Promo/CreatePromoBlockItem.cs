namespace webapi.DTO.Promo
{
    public class CreatePromoBlockItem
    {
        public int Days { get; set; }
        public Guid PromoBlockId { get; set; }
        public Guid? SanatoriumId { get; set; }
        public Guid? RoomId { get; set; }
        public Guid? TourId { get; set; }
        public Guid? TourAgencyId { get; set; }
    }
}
