using Application.Commands;
using Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers
{
    internal class DeleteRoomGroupsCommandHandler : IRequestHandler<DeleteRoomGroupsCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoomGroupRepository _roomGroupRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomReservationRepository _roomReservationRepository;
        private readonly IPromoBlockItemRepository _promoBlockItemRepository;
        private readonly ILogger<DeleteRoomGroupsCommandHandler> _logger;

        public DeleteRoomGroupsCommandHandler(
            IUnitOfWork unitOfWork,
            IRoomGroupRepository roomGroupRepository,
            IRoomRepository roomRepository,
            IRoomReservationRepository roomReservationRepository,
            IPromoBlockItemRepository promoBlockItemRepository,
            ILogger<DeleteRoomGroupsCommandHandler> logger
            )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _roomGroupRepository = roomGroupRepository;
            _roomRepository = roomRepository;
            _roomReservationRepository = roomReservationRepository;
            _promoBlockItemRepository = promoBlockItemRepository;
        }
        public async Task Handle(DeleteRoomGroupsCommand request, CancellationToken cancellationToken)
        {
            var roomGroups = await _roomGroupRepository.FindAsync(s => request.Ids.Contains(s.Id));

            if (!roomGroups.Any())
            {
                return;
            }

            foreach (var group in roomGroups)
            {
                _roomGroupRepository.SetDeletedFlag(group);
            }

            var rooms = await _roomRepository.FindAsync(r => roomGroups.Select(rg => rg.Id).Contains(r.GroupId));
            foreach (var room in rooms)
            {
                _roomRepository.SetDeletedFlag(room);
            }

            var pbi = await _promoBlockItemRepository.FindAsync(r => r.RoomId.HasValue && rooms.Select(r => r.Id).Contains(r.RoomId.Value));
            foreach (var item in pbi)
            {
                _promoBlockItemRepository.SetDeletedFlag(item);
            }

            var reservations = await _roomReservationRepository.FindAsync(rr => rooms.Select(r => r.Id).Contains(rr.RoomId));
            foreach (var res in reservations)
            {
                _roomReservationRepository.SetDeletedFlag(res);
            }

            await _unitOfWork.SaveAsync();
            _logger.LogInformation("Удалены группы комнат: {@ids}", request.Ids);
        }
    }
}
