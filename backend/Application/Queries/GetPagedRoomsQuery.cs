using Application.Models;
using HousingReservation.Domain.Models;
using MediatR;

namespace Application.Queries
{
    public class GetPagedRoomsQuery : IRequest<PagedResult<RoomDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public RoomFilterModel? Filter { get; set; }
    }
}
