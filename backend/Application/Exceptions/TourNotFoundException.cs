namespace Application.Exceptions
{
    public class TourNotFoundException : Exception
    {
        public TourNotFoundException(Guid touId) : base(touId.ToString()) { }
    }
}
