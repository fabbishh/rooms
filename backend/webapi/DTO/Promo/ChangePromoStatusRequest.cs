namespace webapi.DTO.Promo
{
    public class ChangePromoStatusRequest
    {
        public Guid PromoId { get; set; }
        public int Status { get; set; }
        public int PromoType { get; set; }
    }
}
