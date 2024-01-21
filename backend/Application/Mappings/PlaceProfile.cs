using Application.Commands;
using Application.Models;
using AutoMapper;
using HousingReservation.Domain.Entities;

namespace Application.Mappings
{
    public class PlaceProfile : Profile
    {
        public PlaceProfile()
        {
            CreateMap<SavePlaceCommand, Place>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.SubjectId))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => DateTimeOffset.UtcNow))
                .ForMember(dest => dest.Photos, opt => opt.Ignore())
                .ForMember(dest => dest.Subject, opt => opt.Ignore())
                .ForMember(dest => dest.SanatoriumPlaces, opt => opt.Ignore());

            CreateMap<Place, PlaceDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.SubjectId))
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject == null ? "" : src.Subject.NameWithType))
                .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.Photos.Select(p => new PhotoModel { Id = p.Id, Url = p.OriginalUrl})));
        }
    }
}
