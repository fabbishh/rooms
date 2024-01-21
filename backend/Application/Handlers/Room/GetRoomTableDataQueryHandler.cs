using Application.Queries;
using Domain.Common;
using Domain.Enums;
using HousingReservation.Domain.Models;
using MediatR;

namespace Application.Handlers
{
    public class GetRoomTableDataQueryHandler : IRequestHandler<GetRoomTableDataQuery, PagedResult<AdminRoomTable>>
    {
        private readonly IRoomGroupRepository _roomGroupRepository;
        public GetRoomTableDataQueryHandler(IRoomGroupRepository roomGroupRepository)
        {
            _roomGroupRepository = roomGroupRepository;
        }
        public async Task<PagedResult<AdminRoomTable>> Handle(GetRoomTableDataQuery request, CancellationToken cancellationToken)
        {
            var result = await _roomGroupRepository.GetRoomTableData(request.PageNumber, request.PageSize, request.SanatoriumId, (HousingType?)request.HousingType);

            return result;
        }
    }
}
