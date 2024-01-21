using Application.Models;
using Application.Queries;
using AutoMapper;
using HousingReservation.Domain.Common;
using MediatR;

namespace Application.Handlers
{
    internal class GetPlaceQueryHandler : IRequestHandler<GetPlaceQuery, PlaceDto>
    {
        private readonly IPlaceRepository _placeRepository;
        private readonly IMapper _mapper;
        public GetPlaceQueryHandler(IPlaceRepository placeRepository, IMapper mapper)
        {
            _placeRepository = placeRepository;
            _mapper = mapper;
        }
        public async Task<PlaceDto> Handle(GetPlaceQuery request, CancellationToken cancellationToken)
        {
            var place = await _placeRepository.GetByIdAsync(request.PlaceId);

            var mappedPlace = _mapper.Map<PlaceDto>(place);

            return mappedPlace;
        }
    }
}
