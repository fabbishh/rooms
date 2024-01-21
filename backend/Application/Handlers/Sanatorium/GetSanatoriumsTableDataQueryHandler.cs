using Application.Models;
using Application.Queries;
using HousingReservation.Domain.Models;
using HousingReservation.Domain.Sanatoriums;
using MediatR;

namespace Application.Handlers
{
    public class GetSanatoriumsTableDataQueryHandler : IRequestHandler<GetSanatoriumsTableDataQuery, PagedResult<SanatoriumTableRow>>
    {
        private readonly ISanatoriumRepository _sanatoriumRepository;
        public GetSanatoriumsTableDataQueryHandler(ISanatoriumRepository sanatoriumRepository)
        {
            _sanatoriumRepository = sanatoriumRepository;
        }

        public async Task<PagedResult<SanatoriumTableRow>> Handle(GetSanatoriumsTableDataQuery request, CancellationToken cancellationToken)
        {
            var pagedResult = await _sanatoriumRepository.GetPagedAsync(request.PageNumber, request.PageSize);

            var mappedItems = pagedResult.Items.Select(x => new SanatoriumTableRow
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Location = x.Location,
                ObjectType = x.Type.Name!,
                CheckInTime = x.CheckInTime,
                CheckOutTime = x.CheckOutTime,
                Owner = x.Owner?.Email is null ? x.Owner?.PhoneNumber! : x.Owner?.Email!,
                Status = x.Status,
                IsActive = x.IsActive,
                Season = x.Season,
                DateCreated = x.DateCreated,
            }).ToList();

            return new PagedResult<SanatoriumTableRow>(mappedItems, pagedResult.TotalItems, pagedResult.PageNumber, pagedResult.PageSize);
        }
    }
}
