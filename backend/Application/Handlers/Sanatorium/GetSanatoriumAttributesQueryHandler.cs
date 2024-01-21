using Application.Models;
using Application.Queries;
using Domain.Common;
using MediatR;

namespace Application.Handlers
{
    public class GetSanatoriumAttributesQueryHandler : IRequestHandler<GetSanatoriumAttributesQuery, List<SanatoriumAttributeDto>>
    {
        private readonly ISanatoriumAttributeRepository _repository;
        public GetSanatoriumAttributesQueryHandler(ISanatoriumAttributeRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<SanatoriumAttributeDto>> Handle(GetSanatoriumAttributesQuery request, CancellationToken cancellationToken)
        {
            var attributes = await _repository.FindAsync(sa => sa.SanatoriumId == request.SanatoriumId
                                                            && sa.Attribute.AttributeGroup.Name == request.AttributeGroup);

            var response = attributes.Select(a => new SanatoriumAttributeDto
            {
                SanatoriumAttributeId = a.Id,
                IsActive = a.IsActive,
                Name = a.Attribute.FriendlyName,
                GroupName = a.Attribute.AttributeGroup.Name,
            }).ToList();

            return response;
        }
    }
}
