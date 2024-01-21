using Application.Models;
using Application.Queries;
using Domain.Common;
using MediatR;

namespace Application.Handlers
{
    internal class GetRoomAttributesQueryHandler : IRequestHandler<GetRoomAttributesQuery, List<SanatoriumAttributeDto>>
    {
        private readonly IRoomAttributeRepository _roomAttributeRepository;
        public GetRoomAttributesQueryHandler(IRoomAttributeRepository roomAttributeRepository)
        {
            _roomAttributeRepository = roomAttributeRepository;
        }
        public async Task<List<SanatoriumAttributeDto>> Handle(GetRoomAttributesQuery request, CancellationToken cancellationToken)
        {
            var attributes = await _roomAttributeRepository.FindAsync(ra => ra.RoomGroupId == request.RoomGroupId
                                                           && ra.Attribute.AttributeGroup.Name == request.AttributeGroup);

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
