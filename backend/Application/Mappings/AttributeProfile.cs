using Application.Commands;
using AutoMapper;

namespace Application.Mappings
{
    public class AttributeProfile : Profile
    {
        public AttributeProfile()
        {
            CreateMap<CreateAttributeCommand, HousingReservation.Domain.Entities.Attribute>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.FriendlyName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => DateTimeOffset.UtcNow));
        }
    }
}
