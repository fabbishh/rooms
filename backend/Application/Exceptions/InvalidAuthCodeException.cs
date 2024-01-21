namespace Application.Exceptions
{
    public class InvalidAuthCodeException : Exception
    {
        public InvalidAuthCodeException() : base("Код недействителен") { }
    }
}
