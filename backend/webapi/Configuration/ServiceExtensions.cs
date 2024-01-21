using Application.Services;
using DataAccess;
using DataAccess.Repositories;
using Domain.Common;
using HousingReservation.Application.Services;
using HousingReservation.DataAccess.Repositories;
using HousingReservation.Domain.Common;
using HousingReservation.Domain.Sanatoriums;
using Infrastructure.Services.Email;

namespace HousingReservation.WebApi.Configuration
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPhotoManager, PhotoManager>();
            services.AddScoped<IAttributeService, AttributeService>();
            services.AddSingleton<ITokenService, JwtService>();
            services.AddScoped<IRegionService, RegionService>();
            services.AddScoped<IEmailService, EmailService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ISanatoriumRepository, SanatoriumRepository>();
            services.AddScoped<ISanatoriumAttributeRepository, SanatoriumAttributeRepository>();
            services.AddScoped<ISanatoriumPlaceRepository, SanatoriumPlaceRepository>();
            services.AddScoped<ISanatoriumTypeRepository, SanatoriumTypeRepository>();
            services.AddScoped<IFavouriteSanatoriumRepository, FavouriteSanatoriumRepository>();

            services.AddScoped<IPlaceRepository, PlaceRepository>();

            services.AddScoped<IPhotoRepository, PhotoRepository>();

            services.AddScoped<IAttributeRepository, AttributeRepository>();
            
            
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomGroupRepository, RoomGroupRepository>();
            services.AddScoped<IRoomAttributeRepository, RoomAttributeRepository>();
            services.AddScoped<IRoomReservationRepository, RoomReservationRepository>();
            services.AddScoped<IGuestsRepository, GuestsRepository>();

            services.AddScoped<IPromoRowItemRepository, PromoRowItemRepository>();
            services.AddScoped<IPromoBlockItemRepository, PromoBlockItemRepository>();
            services.AddScoped<IPromoBlockRepository, PromoBlockRepository>();
            services.AddScoped<IPromoRowPlanRepository, PromoRowPlanRepository>();

            services.AddScoped<ITourRepository, TourRepository>();
            services.AddScoped<ITourTypeRepository, TourTypeRepository>();
            services.AddScoped<ITourDateRepository, TourDateRepository>();
            services.AddScoped<ITourDateBookingRepository, TourDateBookingRepository>();
            services.AddScoped<ITourAgencyRepository, TourAgencyRepository>();
            services.AddScoped<ITourSeasonRepository, TourSeasonRepository>();
            services.AddScoped<ITourTourSeasonRepository, TourTourSeasonRepository>();
            services.AddScoped<ITourReviewRepository, TourReviewRepository>();

            services.AddScoped<IContactRepository, ContactRepository>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IUserCodeRepository, UserCodeRepository>();

            services.AddScoped<IReviewRepository, ReviewRepository>();

            services.AddScoped<ISubjectRepository, SubjectRepository>();


            return services;
        }


    }
}
