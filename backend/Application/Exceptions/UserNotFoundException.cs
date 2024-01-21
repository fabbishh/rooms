namespace Application.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string? login) : base($"User {login} not found") { }
    }
}
