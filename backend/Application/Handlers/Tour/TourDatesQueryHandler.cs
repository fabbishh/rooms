using Application.Models;
using Application.Queries;
using Domain.Common;
using MediatR;

namespace Application.Handlers
{
    internal class TourDatesQueryHandler : IRequestHandler<TourDatesQuery, List<TourDateResponse>>
    {
        private readonly ITourDateRepository _tourDateRepository;
        private readonly ITourDateBookingRepository _tourDateBookingRepository;
        private readonly ITourRepository _tourRepository;

        public TourDatesQueryHandler(
            ITourDateRepository tourDateRepository, 
            ITourRepository tourRepository, 
            ITourDateBookingRepository tourDateBookingRepository
        )
        {
            _tourDateRepository = tourDateRepository;
            _tourRepository = tourRepository;
            _tourDateBookingRepository = tourDateBookingRepository;
        }

        public async Task<List<TourDateResponse>> Handle(TourDatesQuery request, CancellationToken cancellationToken)
        {
            var tour = await _tourRepository.GetByIdAsync(request.TourId);
            if(tour is null)
            {
                return null;
            }

            var maxTourists = tour.TouristCountFrom;

            var tourDates = await _tourDateRepository.FindAsync(td => td.TourId == request.TourId && td.StartDate.Date > DateTimeOffset.UtcNow.Date);

            var mappedTourDates = new List<TourDateResponse>();

            foreach( var tourDate in tourDates )
            {
                var bookingCount = await _tourDateBookingRepository.GetTourDateBookingCount(tourDate.Id);

                var mappedTourDate = new TourDateResponse
                {
                    Id = tourDate.Id,
                    StartDate = tourDate.StartDate,
                    AvailableSlots = maxTourists - bookingCount
                };
                mappedTourDates.Add(mappedTourDate);
            }

            return mappedTourDates;
        }
    }
}
