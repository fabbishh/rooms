using Application.Extensions;
using Application.Models;
using Application.Queries;
using AutoMapper;
using Domain.Common;
using Domain.Enums;
using HousingReservation.Domain.Entities;
using HousingReservation.Domain.Models;
using MediatR;
using System.Linq.Expressions;

namespace Application.Handlers
{
    public class GetPagedRoomsQueryHandler : IRequestHandler<GetPagedRoomsQuery, PagedResult<RoomDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;
        public GetPagedRoomsQueryHandler(IMapper mapper, IRoomRepository roomRepository)
        {
            _mapper = mapper;
            _roomRepository = roomRepository;
        }
        public async Task<PagedResult<RoomDto>> Handle(GetPagedRoomsQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Room, bool>> filterExpression = r => r.Group.Status == AdminRequestStatus.Confirmed;
            if (request.Filter != null)
            {
                if (request.Filter.SanatoriumId.HasValue)
                {
                    Expression<Func<Room, bool>> sanatoriumFilter = r => r.Group.SanatoriumId == request.Filter.SanatoriumId.Value;
                    filterExpression = filterExpression == null
                        ? sanatoriumFilter
                        : filterExpression.And(sanatoriumFilter);
                }

                if (request.Filter.HousingType.HasValue)
                {
                    Expression<Func<Room, bool>> typeFilter = r => r.Group.HousingType == (HousingType)request.Filter.HousingType;
                    filterExpression = filterExpression == null
                        ? typeFilter
                        : filterExpression.And(typeFilter);
                }

                if (request.Filter.RoomGroupId.HasValue)
                {
                    Expression<Func<Room, bool>> groupFilter = r => r.GroupId == request.Filter.RoomGroupId;
                    filterExpression = filterExpression == null
                        ? groupFilter
                        : filterExpression.And(groupFilter);
                }
            }
            var rooms = await _roomRepository.GetPagedAsync(request.PageNumber, request.PageSize, filterExpression);

            var response = new PagedResult<RoomDto>(_mapper.Map<List<RoomDto>>(rooms.Items), rooms.TotalItems, rooms.PageNumber, rooms.PageSize);

            return response;
        }
    }
}
