using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class DisabledDatesForRoomQuery : IRequest<List<DateRangeModel>>
    {
        public Guid RoomId { get; set; }
    }
}
