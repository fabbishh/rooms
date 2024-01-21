using Application.Extensions;
using Application.Models;
using Application.Queries;
using AutoMapper;
using Domain.Common;
using HousingReservation.Domain.Entities;
using HousingReservation.Domain.Models;
using HousingReservation.Domain.Sanatoriums;
using MediatR;
using System.Linq.Expressions;
using System.Reflection;

namespace Application.Handlers
{
    public class GetPagedSanatoriumsQueryHandler : IRequestHandler<GetPagedSanatoriumsQuery, PagedResult<SanatoriumDto>>
    {
        private readonly ISanatoriumRepository _sanatoriumRepository;
        private readonly IFavouriteSanatoriumRepository _favouriteSanatoriumRepository;
        private readonly IMapper _mapper;
        public GetPagedSanatoriumsQueryHandler(ISanatoriumRepository sanatoriumRepository, IFavouriteSanatoriumRepository favouriteSanatoriumRepository, IMapper mapper)
        {
            _sanatoriumRepository = sanatoriumRepository;
            _favouriteSanatoriumRepository = favouriteSanatoriumRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<SanatoriumDto>> Handle(GetPagedSanatoriumsQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Sanatorium, bool>>? filterExpression = s => s.Status == Domain.Enums.AdminRequestStatus.Confirmed && s.RoomGroups.Any(r => r.Status == Domain.Enums.AdminRequestStatus.Confirmed);

            if (request.RegionId != null)
            {
                Expression<Func<Sanatorium, bool>> regionFilter = s => s.SubjectId == request.RegionId;
                filterExpression = filterExpression == null
                    ? regionFilter
                    : filterExpression.And(regionFilter);
            }

            if (request.ServiceAttributeIds != null && request.ServiceAttributeIds.Any())
            {
                Expression<Func<Sanatorium, bool>> serviceFilter = s => s.SanatoriumAttributes
                                                                        .Any(sa => request.ServiceAttributeIds.Contains(sa.AttributeId));
                filterExpression = filterExpression == null
                    ? serviceFilter
                    : filterExpression.And(serviceFilter);
            }

            if (request.ComfortAttributeIds != null && request.ComfortAttributeIds.Any())
            {
                Expression<Func<Sanatorium, bool>> comfortFilter = s => s.SanatoriumAttributes
                                                                        .Any(sa => request.ComfortAttributeIds.Contains(sa.AttributeId));
                filterExpression = filterExpression == null
                    ? comfortFilter
                    : filterExpression.And(comfortFilter);
            }

            if (request.FoodAttributeIds != null && request.FoodAttributeIds.Any())
            {
                Expression<Func<Sanatorium, bool>> foodFilter = s => s.SanatoriumAttributes
                                                                        .Any(sa => request.FoodAttributeIds.Contains(sa.AttributeId));
                filterExpression = filterExpression == null
                    ? foodFilter
                    : filterExpression.And(foodFilter);
            }

            if (request.BathAttributeIds != null && request.BathAttributeIds.Any())
            {
                Expression<Func<Sanatorium, bool>> bathFilter = s => s.SanatoriumAttributes
                                                                        .Any(sa => request.BathAttributeIds.Contains(sa.AttributeId));
                filterExpression = filterExpression == null
                    ? bathFilter
                    : filterExpression.And(bathFilter);
            }

            if (request.Seasons != null && request.Seasons.Any())
            {
                Expression<Func<Sanatorium, bool>> seasonFilter = s => request.Seasons.Contains((int)s.Season);

                filterExpression = filterExpression == null
                    ? seasonFilter
                    : filterExpression.And(seasonFilter);
            }

            if (request.HousingTypes != null && request.HousingTypes.Any())
            {
                Expression<Func<Sanatorium, bool>> typeFilter = s => s.RoomGroups.Any(r => request.HousingTypes.Contains((int)r.HousingType));

                filterExpression = filterExpression == null
                    ? typeFilter
                    : filterExpression.And(typeFilter);
            }

            if (request.BedroomCounts != null && request.BedroomCounts.Any())
            {
                Expression<Func<Sanatorium, bool>> bedroomFilter = s => s.RoomGroups.Any(r => request.BedroomCounts.Contains(r.BedroomCount));

                filterExpression = filterExpression == null
                    ? bedroomFilter
                    : filterExpression.And(bedroomFilter);
            }

            if (request.PriceFrom.HasValue)
            {
                Expression<Func<Sanatorium, bool>> priceFromFilter = s => s.RoomGroups.Any(r => r.PricePerNight >= request.PriceFrom);

                filterExpression = filterExpression == null
                    ? priceFromFilter
                    : filterExpression.And(priceFromFilter);
            }

            if (request.PriceFrom.HasValue)
            {
                Expression<Func<Sanatorium, bool>> priceToFilter = s => s.RoomGroups.Any(r => r.PricePerNight <= request.PriceTo);

                filterExpression = filterExpression == null
                    ? priceToFilter
                    : filterExpression.And(priceToFilter);
            }

            var pagedResult = await _sanatoriumRepository.GetPagedAsync(
                request.PageNumber, 
                request.PageSize,
                filterExpression);

            var mappedItems = _mapper.Map<List<SanatoriumDto>>(pagedResult.Items);

            foreach (var item in mappedItems)
            {
                item.IsFavourite = await _favouriteSanatoriumRepository.FindOneAsync(s => s.UserId == request.UserId && s.SanatoriumId == item.Id) is not null;
            }

            return new PagedResult<SanatoriumDto>(mappedItems, pagedResult.TotalItems, pagedResult.PageNumber, pagedResult.PageSize);
        }
    }
}
