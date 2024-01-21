using Application.Commands;
using Application.Models;
using AutoMapper;
using HousingReservation.Domain.Entities;

namespace HousingReservation.Application.Mappings
{
    public class SanatoriumProfile : Profile
    {
        public SanatoriumProfile()
        {
            CreateMap<SaveSanatoriumCommand, Sanatorium>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id.HasValue ? src.Id.Value : Guid.NewGuid()))
                .ForMember(dst => dst.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.OwnerId, opt => opt.MapFrom(src => src.OwnerId))
                .ForMember(dst => dst.CheckInTime, opt => opt.MapFrom(src => src.CheckInTime))
                .ForMember(dst => dst.CheckOutTime, opt => opt.MapFrom(src => src.CheckOutTime))
                .ForMember(dst => dst.Season, opt => opt.MapFrom(src => src.Season))
                .ForMember(dst => dst.TypeId, opt => opt.MapFrom(src => src.ObjectType))
                .ForMember(dst => dst.DateCreated, opt => opt.MapFrom(src => DateTimeOffset.UtcNow))
                .ForMember(dst => dst.SubjectId, opt => opt.MapFrom(src => src.SubjectId))
                .ForMember(dst => dst.Photo, opt => opt.Ignore())
                .ForMember(dst => dst.Description, opt => opt.Ignore());

            CreateMap<Sanatorium, SanatoriumDto>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.PhotoUrl, opt => opt.MapFrom(src => src.Photo == null ? "" : src.Photo.OriginalUrl))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Address, opt => opt.MapFrom(src => src.Location))
                .ForMember(dst => dst.SubjectId, opt => opt.MapFrom(src => src.SubjectId))
                .ForMember(dst => dst.SubjectName, opt => opt.MapFrom(src => src.Subject.Name))
                .ForMember(dst => dst.Season, opt => opt.MapFrom(src => src.Season))
                .ForMember(dst => dst.PriceFrom, opt => opt.MapFrom(src => src.RoomGroups.Select(rg => rg.PricePerNight).OrderBy(p => p).FirstOrDefault()));

            CreateMap<Sanatorium, SanatoriumDetailsDto>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                //.ForMember(dst => dst.PhotoUrls, opt => opt.MapFrom(src => src.Photos.Select(p => p.OriginalUrl)))
                .ForMember(dst => dst.SubjectId, opt => opt.MapFrom(src => src.SubjectId))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dst => dst.SubjectName, opt => opt.MapFrom(src => src.Subject.Name))
                .ForMember(dst => dst.Attributes, opt => opt.MapFrom(src => src.SanatoriumAttributes.Select(sa => new SanatoriumAttributeDto
                {
                    SanatoriumAttributeId = sa.Id,
                    Name = sa.Attribute.Name,
                    GroupName = sa.Attribute.AttributeGroup.Name,
                    IsActive = sa.IsActive
                })));



        }
    }
}
