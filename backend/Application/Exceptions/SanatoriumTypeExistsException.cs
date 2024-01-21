namespace Application.Exceptions
{
    internal class SanatoriumTypeExistsException : Exception
    {
        public SanatoriumTypeExistsException(string name) : base($"Тип {name} уже существует") { }
    }
}
