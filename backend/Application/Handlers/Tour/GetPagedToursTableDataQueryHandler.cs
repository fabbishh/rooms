using Application.Extensions;
using Application.Models;
using Application.Queries;
using Domain.Common;
using HousingReservation.Domain.Entities;
using HousingReservation.Domain.Models;
using MediatR;
using System.Linq.Expressions;

namespace Application.Handlers
{
    public class GetPagedToursTableDataQueryHandler : IRequestHandler<GetPagedToursTableDataQuery, PagedResult<ToursTableRow>>
    {
        private readonly ITourRepository _tourRepository;
        public GetPagedToursTableDataQueryHandler(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }

        public async Task<PagedResult<ToursTableRow>> Handle(GetPagedToursTableDataQuery request, CancellationToken cancellationToken)
        {
            var filterExpression = CreateFilterExpression(request.Filter);
            var pagedResult = await _tourRepository.GetPagedAsync(request.PageNumber, request.PageSize, filterExpression);

            var mappedItems = pagedResult.Items.Select(t => new ToursTableRow
            {
                Id = t.Id,
                DateCreated = t.DateCreated,
                Name = t.Name,
                ClosestDates = t.TourDates.Where(t => t.StartDate.Date >= DateTimeOffset.UtcNow.Date).OrderBy(t => t.StartDate).Select(t => t.StartDate).ToList(),
                Status = t.Status,
                Subject = t.Subject.NameWithType,
                PromoInfo = null,
                TourAgencyId = t.TourAgencyId,
                TourAgencyName = t.TourAgency?.Name
            }).ToList();

            var response = new PagedResult<ToursTableRow>(mappedItems, pagedResult.TotalItems, pagedResult.PageNumber, pagedResult.PageSize);

            return response;
        }

        private Expression<Func<Tour, bool>>? CreateFilterExpression(TourFilterModel? filter)
        {
            if (filter == null)
            {
                return null;
            }
            Expression<Func<Tour, bool>>? filterExpression = null;

            if (filter.TourAgencyId.HasValue)
            {
                Expression<Func<Tour, bool>> agencyFilter = t => t.TourAgencyId == filter.TourAgencyId.Value;

                filterExpression = filterExpression == null
                    ? agencyFilter
                    : filterExpression.And(agencyFilter);
            }

            return filterExpression;
        }
    }
}
