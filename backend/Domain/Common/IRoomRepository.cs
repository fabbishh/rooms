using HousingReservation.Domain.Common;
using HousingReservation.Domain.Entities;

namespace Domain.Common
{
    public interface IRoomRepository : IPagedRepository<Room>
    {
        Task<Room> GetRoomDetailsAsync(Guid roomId);
    }
}
