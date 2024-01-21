using Application.Models;
using Application.Queries;
using Domain.Common;
using Domain.Enums;
using HousingReservation.Domain.Entities;
using MediatR;

namespace Application.Handlers
{
    public class GetTourFormDataQueryHandler : IRequestHandler<GetTourFormDataQuery, TourFormData?>
    {
        private readonly ITourRepository _tourRepository;
        public GetTourFormDataQueryHandler(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }
        public async Task<TourFormData?> Handle(GetTourFormDataQuery request, CancellationToken cancellationToken)
        {
            var tour = await _tourRepository.GetByIdAsync(request.TourId);
            if (tour is null)
            {
                return null;
            }

            var mappedTour = new TourFormData
            {
                Id = tour.Id,
                Days = tour.Days,
                Description = tour.Description,
                IsActive = tour.IsActive,
                Name = tour.Name,
                Price = tour.PriceByGroup is null ? tour.PriceByTourist!.Value : tour.PriceByGroup.Value!,
                PriceType = tour.PriceByGroup is null ? TourPriceType.ByTourist : TourPriceType.ByGroup,
                TouristCountFrom = tour.TouristCountFrom,
                TouristCountTo = tour.TouristCountTo,
                TourAgencyId = tour.TourAgencyId,
                Subject = tour.SubjectId,
                Type = tour.TypeId,
                Status = tour.Status,
                SubjectName = tour.Subject?.NameWithType,
                TourAgencyName = tour.TourAgency.Name,
                TypeName = tour.Type?.Name,
                Photos = tour.Photos.Select(p => new PhotoModel { Id = p.Id, Url = p.OriginalUrl }).ToList(),
                StartDates = tour.TourDates.Select(d => new TourStartDate { Id = d.Id, StartDate = d.StartDate }).OrderBy(d => d.StartDate).ToList(),
                Seasons = tour.Seasons.Select(ts => ts.TourSeason.Value).ToList()
            };

            return mappedTour;
        }
    }
}
