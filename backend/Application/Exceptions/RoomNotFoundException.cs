namespace Application.Exceptions
{
    public class RoomNotFoundException : Exception
    {
        public RoomNotFoundException(Guid roomId) : base(roomId.ToString()) { }
    }
}
