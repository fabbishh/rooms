namespace Application.Exceptions
{
    public class UserExistsException : Exception
    {
        public UserExistsException(string? email, string? phoneNumber)
            : base(email == null ? $"Пользователь с телефоном {phoneNumber} уже существует" : $"Пользователь с email {email} уже существует") { }
    }
}
