using Domain.Enums;
using HousingReservation.Domain.Common;
using HousingReservation.Domain.Entities;
using HousingReservation.Domain.Models;

namespace Domain.Common
{
    public interface IRoomGroupRepository : IPagedRepository<RoomGroup>
    {
        Task<PagedResult<AdminRoomTable>> GetRoomTableData(int pageNumber, int pageSize, Guid? sanatoriumId, HousingType? housingType);
    }
}
