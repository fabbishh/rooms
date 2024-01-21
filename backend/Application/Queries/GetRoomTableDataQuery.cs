using HousingReservation.Domain.Models;
using MediatR;

namespace Application.Queries
{
    public class GetRoomTableDataQuery : IRequest<PagedResult<AdminRoomTable>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public Guid? SanatoriumId { get; set; }
        public int? HousingType { get; set; }
    }
}
