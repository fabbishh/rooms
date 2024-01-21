using Application.Models;
using Application.Queries;
using Domain.Common;
using MediatR;

namespace Application.Handlers
{
    public class GetTourTypesQueryHandler : IRequestHandler<GetTourTypesQuery, List<TourTypeModel>>
    {
        private readonly ITourTypeRepository _tourTypeRepository;
        public GetTourTypesQueryHandler(ITourTypeRepository tourTypeRepository)
        {
            _tourTypeRepository = tourTypeRepository;
        }
        public async Task<List<TourTypeModel>> Handle(GetTourTypesQuery request, CancellationToken cancellationToken)
        {
            var tourTypes = await _tourTypeRepository.GetAllAsync();

            var mappedTourTypes = tourTypes.Select(tt => new TourTypeModel { Id = tt.Id, Name = tt.Name });

            return mappedTourTypes.ToList();
        }
    }
}
