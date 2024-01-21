using Application.Models;
using AutoMapper;
using HousingReservation.Domain.Entities;

namespace Application.Mappings
{
    public class PromoRowItemProfile : Profile
    {
        public PromoRowItemProfile()
        {
            CreateMap<PromoRowItem, PromoRowItemDto>();
        }
    }
}
