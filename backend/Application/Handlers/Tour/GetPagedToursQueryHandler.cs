using Application.Extensions;
using Application.Models;
using Application.Queries;
using Domain.Common;
using HousingReservation.Domain.Entities;
using HousingReservation.Domain.Models;
using MediatR;
using System.Linq.Expressions;
using System.Reflection;

namespace Application.Handlers
{
    public class GetPagedToursQueryHandler : IRequestHandler<GetPagedToursQuery, PagedResult<PagedToursItem>>
    {
        private readonly ITourRepository _tourRepository;
        public GetPagedToursQueryHandler(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }

        public async Task<PagedResult<PagedToursItem>> Handle(GetPagedToursQuery request, CancellationToken cancellationToken)
        {
            var filterExpression = CreateFilterExpression(request.Filter);
            var pagedResult = await _tourRepository.GetPagedAsync(request.PageNumber, request.PageSize, filterExpression);

            var mappedItems = pagedResult.Items.Where(i => i.Status == Domain.Enums.AdminRequestStatus.Confirmed).Select(t => new PagedToursItem
            {
                Id = t.Id,
                Days = t.Days,
                Description = t.Description,
                ClosestDate = t.TourDates
                            .Where(td => td.StartDate.Day >= DateTimeOffset.UtcNow.Day)
                            .OrderBy(td => td.StartDate)
                            .FirstOrDefault()?.StartDate,
                TouristCountFrom = t.TouristCountFrom,
                TouristCountTo = t.TouristCountTo,
                Name = t.Name,
                PriceByGroup = t.PriceByGroup,
                PriceByTourist = t.PriceByTourist,
                Organizer = new TourOrganizerDto
                {
                    Id = t.TourAgencyId,
                    Name = t.TourAgency.Name,
                }
            }).ToList();

            var response = new PagedResult<PagedToursItem>(mappedItems, pagedResult.TotalItems, pagedResult.PageNumber, pagedResult.PageSize);
            
            return response;
        }

        private Expression<Func<Tour, bool>>? CreateFilterExpression(TourFilterModel? filter)
        {
            if (filter == null)
            {
                return null;
            }
            Expression<Func<Tour, bool>>? filterExpression = t => t.Status == Domain.Enums.AdminRequestStatus.Confirmed;

            if(filter.SubjectId.HasValue)
            {
                Expression<Func<Tour, bool>> regionFilter = t => t.SubjectId == filter.SubjectId.Value;

                filterExpression = filterExpression == null
                    ? regionFilter
                    : filterExpression.And(regionFilter);
            }

            if (filter.StartDate.HasValue)
            {
                Expression<Func<Tour, bool>> startDateFilter = t => t.TourDates.Any() &&
                         t.TourDates!.OrderBy(td => td.StartDate)
                         .FirstOrDefault(td => td.StartDate > DateTimeOffset.UtcNow && td.StartDate >= filter.StartDate.Value) != null;

                filterExpression = filterExpression == null
                    ? startDateFilter
                    : filterExpression.And(startDateFilter);
            }

            if (filter.EndDate.HasValue)
            {
                Expression<Func<Tour, bool>> endDateFilter = t => t.TourDates.Any() &&
                        t.TourDates!.OrderBy(td => td.StartDate)
                        .FirstOrDefault(td => td.StartDate > DateTimeOffset.UtcNow && td.StartDate <= filter.EndDate.Value) != null;

                filterExpression = filterExpression == null
                    ? endDateFilter
                    : filterExpression.And(endDateFilter);
            }

            if (filter.TouristsFrom.HasValue)
            {
                Expression<Func<Tour, bool>> touristsFromFilter = t => t.TouristCountFrom >= filter.TouristsFrom.Value;
                filterExpression = filterExpression == null
                    ? touristsFromFilter
                    : filterExpression.And(touristsFromFilter);
            }

            if (filter.TouristsTo.HasValue)
            {
                Expression<Func<Tour, bool>> touristsToFilter = t => t.TouristCountTo <= filter.TouristsTo.Value;
                filterExpression = filterExpression == null
                    ? touristsToFilter
                    : filterExpression.And(touristsToFilter);
            }

            if (filter.PriceFrom.HasValue)
            {
                Expression<Func<Tour, bool>> priceFromFilter = t => t.PriceByTourist != null && t.PriceByTourist >= filter.PriceFrom.Value
                                                                    || t.PriceByGroup != null && t.PriceByGroup >= filter.PriceFrom.Value;
                filterExpression = filterExpression == null
                    ? priceFromFilter
                    : filterExpression.And(priceFromFilter);
            }

            if (filter.PriceTo.HasValue)
            {
                Expression<Func<Tour, bool>> priceToFilter = t => t.PriceByTourist != null && t.PriceByTourist <= filter.PriceTo.Value
                                                                    || t.PriceByGroup != null && t.PriceByGroup <= filter.PriceTo.Value;
                filterExpression = filterExpression == null
                    ? priceToFilter
                    : filterExpression.And(priceToFilter);
            }

            if(filter.DaysFrom.HasValue)
            {
                Expression<Func<Tour, bool>> daysFromFilter = t => t.Days >= filter.DaysFrom.Value;

                filterExpression = filterExpression == null
                    ? daysFromFilter
                    : filterExpression.And(daysFromFilter);
            }

            if (filter.DaysTo.HasValue)
            {
                Expression<Func<Tour, bool>> daysToFilter = t => t.Days <= filter.DaysTo.Value;

                filterExpression = filterExpression == null
                    ? daysToFilter
                    : filterExpression.And(daysToFilter);
            }

            if (filter.TourType.HasValue)
            {
                Expression<Func<Tour, bool>> typeFilter = t => t.TypeId == filter.TourType;

                filterExpression = filterExpression == null
                    ? typeFilter
                    : filterExpression.And(typeFilter);
            }

            if(filter.Seasons is not null && filter.Seasons.Count > 0)
            {
                var seasonValues = filter.Seasons;
                Expression<Func<Tour, bool>> seasonsFilter = t => t.Seasons.Any(s => seasonValues.Contains(s.TourSeason.Value) || s.TourSeason.Value == 4);
                filterExpression = filterExpression == null
                ? seasonsFilter
                   : filterExpression.And(seasonsFilter);
            }

            return filterExpression;
        }
    }
}
