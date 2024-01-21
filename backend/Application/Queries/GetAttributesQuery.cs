using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class GetAttributesQuery : IRequest<List<AttributeDto>>
    {
        public string AttributeGroup { get; set; }
    }
}
