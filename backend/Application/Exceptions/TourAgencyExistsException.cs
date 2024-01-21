namespace Application.Exceptions
{
    public class TourAgencyExistsException : Exception
    {
        public TourAgencyExistsException(string name) : base($"Турагенство с названием '{name}' уже существует") { }
    }
}
