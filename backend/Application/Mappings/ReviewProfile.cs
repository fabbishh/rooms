using Application.Models;
using AutoMapper;
using HousingReservation.Domain.Entities;

namespace Application.Mappings
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
                .ForMember(dest => dest.OverallRating, opt => opt.MapFrom(src => src.OverallRating))
                .ForMember(dest => dest.StaffRating, opt => opt.MapFrom(src => src.StaffRating))
                .ForMember(dest => dest.TherapyRating, opt => opt.MapFrom(src => src.TherapyRating))
                .ForMember(dest => dest.CleanlinessRating, opt => opt.MapFrom(src => src.CleanlinessRating))
                .ForMember(dest => dest.FoodRating, opt => opt.MapFrom(src => src.FoodRating))
                .ForMember(dest => dest.LocationRating, opt => opt.MapFrom(src => src.LocationRating))
                .ForMember(dest => dest.EntertainmentRating, opt => opt.MapFrom(src => src.EntertainmentRating))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.DateCreated));


        }
    }
}
