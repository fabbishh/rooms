using Application.Models;
using AutoMapper;
using HousingReservation.Domain.Entities;

namespace Application.Mappings
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomDto>()
                .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Group.Name} {src.Name}"))
                .ForMember(dest => dest.PricePerNight, opt => opt.MapFrom(src => src.Group.PricePerNight))
                .ForMember(dest => dest.BedroomCount, opt => opt.MapFrom(src => src.Group.BedroomCount))
                .ForMember(dest => dest.SingleBedCount, opt => opt.MapFrom(src => src.Group.SingleBedCount))
                .ForMember(dest => dest.DoubleBedCount, opt => opt.MapFrom(src => src.Group.DoubleBedCount))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Group.Description))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)src.Group.Status))
                .ForMember(dest => dest.PhotoUrls, opt => opt.MapFrom(src => src.Group.Photos.Select(p => p.OriginalUrl)));
        }
    }
}
