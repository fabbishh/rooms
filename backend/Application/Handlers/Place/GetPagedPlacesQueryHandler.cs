using Application.Extensions;
using Application.Models;
using Application.Queries;
using AutoMapper;
using HousingReservation.Domain.Common;
using HousingReservation.Domain.Entities;
using HousingReservation.Domain.Models;
using MediatR;
using System.Linq.Expressions;

namespace Application.Handlers
{
    public class GetPagedPlacesQueryHandler : IRequestHandler<GetPagedPlacesQuery, PagedResult<PlaceDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPlaceRepository _placeRepository;
        public GetPagedPlacesQueryHandler(IMapper mapper, IPlaceRepository placeRepository)
        {
            _mapper = mapper;
            _placeRepository = placeRepository;
        }

        public async Task<PagedResult<PlaceDto>> Handle(GetPagedPlacesQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Place, bool>> filterExpression = null;
            if (request.SanatoriumId.HasValue)
            {
                filterExpression = p => p.SanatoriumPlaces.Any(sp => sp.SanatoriumId == request.SanatoriumId.Value);
            }

            var searchQuery = request.SearchQuery?.Trim().ToLowerInvariant();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                Expression<Func<Place, bool>> nameFilter = p => p.Name.ToLower().Contains(searchQuery);
                filterExpression = filterExpression == null
                    ? nameFilter
                    : filterExpression.And(nameFilter);
            }



            var pagedResult = await _placeRepository.GetPagedAsync(request.PageNumber, request.PageSize, filterExpression);

            var places = _mapper.Map<List<PlaceDto>>(pagedResult.Items);

            var response = new PagedResult<PlaceDto>(places, pagedResult.TotalItems, pagedResult.PageNumber, pagedResult.PageSize);

            return response;
        }
    }
}
