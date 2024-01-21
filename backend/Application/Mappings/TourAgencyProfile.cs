using Application.Commands;
using AutoMapper;
using HousingReservation.Domain.Entities;

namespace Application.Mappings
{
    public class TourAgencyProfile : Profile
    {
        public TourAgencyProfile()
        {
            CreateMap<SaveTourAgencyCommand, TourAgency>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.HasValue ? src.Id.Value : Guid.NewGuid()))
                .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.OwnerId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Link, opt => opt.MapFrom(src => src.Link))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => DateTimeOffset.UtcNow))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
               // .ForMember(dest => dest.Photos, opt => opt.Ignore())
                .ForMember(dest => dest.Tours, opt => opt.Ignore())
                .ForMember(dest => dest.Contacts, opt => opt.Ignore());
        }
    }
}
