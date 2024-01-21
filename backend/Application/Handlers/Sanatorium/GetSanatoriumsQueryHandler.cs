using Application.Models;
using Application.Queries;
using HousingReservation.Domain.Sanatoriums;
using MediatR;

namespace Application.Handlers
{
    internal class GetSanatoriumsQueryHandler : IRequestHandler<GetSanatoriumsQuery, List<SelectItemModel>>
    {
        private readonly ISanatoriumRepository _sanatoriumRepository;
        public GetSanatoriumsQueryHandler(ISanatoriumRepository sanatoriumRepository)
        {
            _sanatoriumRepository = sanatoriumRepository;
        }
        public async Task<List<SelectItemModel>> Handle(GetSanatoriumsQuery request, CancellationToken cancellationToken)
        {
            var sanatoriums = await _sanatoriumRepository.FindAsync(s => s.Status == Domain.Enums.AdminRequestStatus.Confirmed);
            var mappedItems = sanatoriums.Select(x => new SelectItemModel
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            return mappedItems;
        }
    }
}
