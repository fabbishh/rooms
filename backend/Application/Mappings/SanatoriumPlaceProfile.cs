using Application.Commands;
using AutoMapper;
using HousingReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class SanatoriumPlaceProfile : Profile
    {
        public SanatoriumPlaceProfile()
        {
            CreateMap<CreateSanatoriumPlaceCommand, SanatoriumPlace>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dst => dst.SanatoriumId, opt => opt.MapFrom(src => src.SanatoriumId))
                .ForMember(dst => dst.PlaceId, opt => opt.MapFrom(src => src.PlaceId));
        }
    }
}
