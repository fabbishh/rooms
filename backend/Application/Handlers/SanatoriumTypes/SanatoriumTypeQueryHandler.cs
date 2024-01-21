using Application.Models;
using Application.Queries;
using Domain.Common;
using MediatR;

namespace Application.Handlers.SanatoriumTypes
{
    internal class SanatoriumTypeQueryHandler : IRequestHandler<SanatoriumTypeQuery, List<SanatoriumTypeModel>>
    {
        private readonly ISanatoriumTypeRepository _repository;
        public SanatoriumTypeQueryHandler(ISanatoriumTypeRepository sanatoriumTypeRepository)
        {
            _repository = sanatoriumTypeRepository;
        }
        public async Task<List<SanatoriumTypeModel>> Handle(SanatoriumTypeQuery request, CancellationToken cancellationToken)
        {
            var types = await _repository.GetAllAsync();

            var mappedTypes = types.Select(t => new SanatoriumTypeModel
            {
                Id = t.Id,
                Name = t.Name,
                DateCreated = t.DateCreated,
                IsActive = t.IsActive,
            }).ToList();

            return mappedTypes;
        }
    }
}
