using Domain.Entities;
using HousingReservation.Domain.Entities;

namespace Application.Services
{
    public interface IAttributeService
    {
        Task UpdateSanatoriumAttributes(List<SanatoriumAttribute> sanatoriumAttributes);
        Task UpdateRoomAttributes(List<RoomAttribute> roomAttributes);
        Task AddAttributeToSanatoriums(HousingReservation.Domain.Entities.Attribute attribute);
        Task AddAttributeToRoomGroups(HousingReservation.Domain.Entities.Attribute attribute);
    }
}
