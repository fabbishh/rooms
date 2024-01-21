using Application.Models;
using Application.Queries;
using Domain.Common;
using MediatR;

namespace Application.Handlers
{
    public class GetAttributesQueryHandler : IRequestHandler<GetAttributesQuery, List<AttributeDto>>
    {
        private readonly IAttributeRepository _attributeRepository;
        public GetAttributesQueryHandler(IAttributeRepository attributeRepository)
        {
            _attributeRepository = attributeRepository;
        }

        public async Task<List<AttributeDto>> Handle(GetAttributesQuery request, CancellationToken cancellationToken)
        {
            var attributes = await _attributeRepository.FindAsync(a => a.AttributeGroup.Name == request.AttributeGroup);

            var mappedAttributes = attributes.Select(a => new AttributeDto
            {
                Id = a.Id,
                Name = a.FriendlyName,
                IsActive = a.IsActive,
            }).ToList();

            return mappedAttributes;
        }
    }
}
