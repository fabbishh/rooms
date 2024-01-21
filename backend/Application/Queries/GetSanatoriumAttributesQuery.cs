using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class GetSanatoriumAttributesQuery : IRequest<List<SanatoriumAttributeDto>>
    {
        public Guid SanatoriumId { get; set; }
        public string AttributeGroup { get; set; }
    }
}
