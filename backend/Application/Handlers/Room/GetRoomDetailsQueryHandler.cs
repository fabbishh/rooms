using Application.Models;
using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Controllers;

namespace Application.Handlers
{
    public class GetRoomDetailsQueryHandler : IRequestHandler<GetRoomDetailsQuery, RoomDetailsModel>
    {
        private readonly IRoomRepository _roomRepository;
        public GetRoomDetailsQueryHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<RoomDetailsModel> Handle(GetRoomDetailsQuery request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetRoomDetailsAsync(request.RoomId);

            if(room is null)
            {
                return null;
            }

            var mappedRoom = new RoomDetailsModel
            {
                Id = room.Id,
                Name = $"{room.Group?.Name} {room?.Name}",
                BedroomCount = room.Group.BedroomCount,
                Description = room.Group.Description,
                DoubleBedCount = room.Group.DoubleBedCount,
                SingleBedCount = room.Group.SingleBedCount,
                PricePerNight = room.Group.PricePerNight,
                PhotoUrls = room.Group!.Photos?.Select(p => p.OriginalUrl).ToList(),
                RoomGroupId = room.Group!.Id,
            };

            return mappedRoom;
        }
    }
}
