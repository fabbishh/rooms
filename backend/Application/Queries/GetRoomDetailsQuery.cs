using Application.Models;
using MediatR;

namespace webapi.Controllers
{
    public class GetRoomDetailsQuery : IRequest<RoomDetailsModel>
    {
        public Guid RoomId { get; set; }
    }
}
