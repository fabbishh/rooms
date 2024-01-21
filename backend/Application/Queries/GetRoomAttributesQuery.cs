using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class GetRoomAttributesQuery : IRequest<List<SanatoriumAttributeDto>>
    {
        public Guid RoomGroupId { get; set; }
        public string AttributeGroup { get; set; }
    }
}
