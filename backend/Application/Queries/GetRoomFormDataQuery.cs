using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class GetRoomFormDataQuery : IRequest<RoomFormData?>
    {
        public Guid RoomGroupId { get; set; }
    }
}
