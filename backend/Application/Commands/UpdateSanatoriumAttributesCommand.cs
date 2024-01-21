using Application.Models;
using MediatR;

namespace Application.Commands
{
    public class UpdateSanatoriumAttributesCommand : IRequest
    {
        public List<CreateSanatoriumAttributeDto> SanatoriumAttributes { get; set; }
        public string AttributeGroup { get; set; }  
    }
}
