using Application.Commands;
using AutoMapper;
using Domain.Enums;
using HousingReservation.Domain.Entities;

namespace Application.Mappings
{
    public class RoomReservationProfile : Profile
    {
        public RoomReservationProfile()
        {
            CreateMap<CreateRoomReservationCommand, RoomReservation>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
               // .ForMember(dest => dest.GuestsCount, opt => opt.MapFrom(src => src.GuestsCount))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => DateTimeOffset.UtcNow))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => AdminRequestStatus.Pending));   
        }
    }
}
