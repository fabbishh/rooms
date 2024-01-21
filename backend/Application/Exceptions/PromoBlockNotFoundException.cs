namespace Application.Exceptions
{
    public class PromoBlockNotFoundException : Exception
    {
        public PromoBlockNotFoundException(Guid promoBlockId) : base($"Промо блок {promoBlockId} не найден.") { }
    }
}
