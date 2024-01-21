using Application.Models;
using Application.Queries;
using Domain.Common;
using HousingReservation.Domain.Models;
using MediatR;

namespace Application.Handlers
{
    internal class GetTourAgenciesTableDataQueryHandler : IRequestHandler<GetTourAgenciesTableDataQuery, PagedResult<TourAgencyTableRow>>
    {
        private readonly ITourAgencyRepository _tourAgencyRepository;
        public GetTourAgenciesTableDataQueryHandler(ITourAgencyRepository tourAgencyRepository)
        {
            _tourAgencyRepository = tourAgencyRepository;
        }
        public async Task<PagedResult<TourAgencyTableRow>> Handle(GetTourAgenciesTableDataQuery request, CancellationToken cancellationToken)
        {
            var pagedResult = await _tourAgencyRepository.GetPagedAsync(request.PageNumber, request.PageSize);

            var mappedItems = pagedResult.Items.Select(x => new TourAgencyTableRow
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                IsActive = x.IsActive,
                Link = x.Link,
                Location = x.Location,
                Owner = x.Owner.Email == null ? x.Owner.PhoneNumber! : x.Owner.Email!,
                Status = x.Status,
                DateCreated = x.DateCreated,
            }).ToList();

            return new PagedResult<TourAgencyTableRow>(mappedItems, pagedResult.TotalItems, pagedResult.PageNumber, pagedResult.PageSize);
        }
    }
}
