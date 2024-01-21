using Application.Models;
using Application.Queries;
using Domain.Common;
using MediatR;

namespace Application.Handlers
{
    internal class TourAgencyListQueryHandler : IRequestHandler<TourAgencyListQuery, List<TourAgencyListItem>>
    {
        private readonly ITourAgencyRepository _tourAgencyRepository;
        public TourAgencyListQueryHandler(ITourAgencyRepository tourAgencyRepository)
        {
            _tourAgencyRepository = tourAgencyRepository;
        }
        public async Task<List<TourAgencyListItem>> Handle(TourAgencyListQuery request, CancellationToken cancellationToken)
        {
            var items = await _tourAgencyRepository.FindAsync(ta => ta.Status == Domain.Enums.AdminRequestStatus.Confirmed);

            var mappedItems = items.Select(x => new TourAgencyListItem
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            return mappedItems;
        }
    }
}
