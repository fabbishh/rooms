using Application.Commands;
using Application.Services;
using Domain.Common;
using HousingReservation.Domain.Entities;
using HousingReservation.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers
{
    internal class UpdateRoomsCommandHandler : IRequestHandler<UpdateRoomsCommand>
    {
        private readonly IRoomGroupRepository _roomGroupRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IPhotoRepository _photoRepository;
        private readonly IPhotoManager _photoManager;
        private readonly IRoomAttributeRepository _roomAttributeRepository;
        private readonly IRoomReservationRepository _roomReservationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateRoomsCommandHandler> _logger;

        public UpdateRoomsCommandHandler(
            IRoomGroupRepository roomGroupRepository,
            IPhotoRepository photoRepository,
            IRoomRepository roomRepository,
            IRoomReservationRepository roomReservationRepository,
            IPhotoManager photoManager,
            IUnitOfWork unitOfWork,
            IRoomAttributeRepository roomAttributeRepository,
            ILogger<UpdateRoomsCommandHandler> logger
            )
        {
            _photoRepository = photoRepository;
            _roomGroupRepository = roomGroupRepository;
            _roomRepository = roomRepository;
            _photoManager = photoManager;
            _unitOfWork = unitOfWork;
            _roomAttributeRepository = roomAttributeRepository;
            _roomReservationRepository = roomReservationRepository;
            _logger = logger;
        }

        public async Task Handle(UpdateRoomsCommand request, CancellationToken cancellationToken)
        {
            var existingRoomGroup = await _roomGroupRepository.GetByIdAsync(request.Id);
            if (existingRoomGroup is null)
            {
                throw new InvalidOperationException("Комнаты не существуют");
            }

            existingRoomGroup.Name = request.Name;
            existingRoomGroup.Id = request.Id;
            existingRoomGroup.MinDaysReservation = request.MinDaysReservation;
            existingRoomGroup.RoomType = (RoomType)request.RoomType;
            existingRoomGroup.BedroomCount = request.BedroomCount;
            existingRoomGroup.SingleBedCount = request.SingleBedCount;
            existingRoomGroup.DoubleBedCount = request.DoubleBedCount;
            existingRoomGroup.PricePerNight = request.PricePerNight;
            existingRoomGroup.Description = request.Description;
            existingRoomGroup.SanatoriumId = request.SanatoriumId;
            existingRoomGroup.Status = request.Status;

            _roomGroupRepository.Update(existingRoomGroup);

            //добавление фото для группы комнат
            if (request.NewPhotos is not null && request.NewPhotos.Any())
            {
                var savedOnDiskPhotos = _photoManager.SavePhotoOnDisk(request.NewPhotos);

                foreach (var photo in savedOnDiskPhotos)
                {
                    photo.RoomGroupId = existingRoomGroup.Id;
                    await _photoRepository.AddAsync(photo);
                }
            }

            //удаление фото
            if (request.DeletedPhotos is not null && request.DeletedPhotos.Any())
            {
                var photosToDelete = await _photoRepository.FindAsync(p => request.DeletedPhotos.Contains(p.Id));
                _photoManager.DeletePhotosFromDisk(photosToDelete.ToList());
                foreach (var photo in photosToDelete)
                {
                    _photoRepository.SetDeletedFlag(photo);
                }
            }

            //удаление комнат если счетчик уменьшился
            if (request.SameRoomCount < existingRoomGroup.Quantity)
            {
                var existingRooms = await _roomRepository.FindAsync(r => r.GroupId == existingRoomGroup.Id);

                var countRoomsToRemove = existingRoomGroup.Quantity - request.SameRoomCount;


                var roomsToDelete = existingRooms
                    .GroupBy(room => new
                    {
                        ReservationCount = room.Reservations.Count,
                        DateCreated = room.DateCreated
                    })
                    .OrderBy(group => group.Key.ReservationCount)
                    .ThenByDescending(group => group.Key.DateCreated)
                    .SelectMany(group => group)
                    .Take(countRoomsToRemove);

                foreach (var room in roomsToDelete)
                {
                    _roomRepository.SetDeletedFlag(room);
                }

                var reservationsToDelete = await _roomReservationRepository.FindAsync(r => roomsToDelete.Select(r => r.Id).Contains(r.RoomId));

                foreach (var reservation in reservationsToDelete)
                {
                    _roomReservationRepository.SetDeletedFlag(reservation);
                }

            }

            //добавление комнат если счетчик увеличился
            if (request.SameRoomCount > existingRoomGroup.Quantity)
            {
                var countRoomsToAdd = request.SameRoomCount - existingRoomGroup.Quantity;
                var roomCount = (await _roomRepository.FindAsync(r => r.GroupId == existingRoomGroup.Id)).Count();
                for (var i = 0; i < countRoomsToAdd; i++)
                {
                    var room = new Room
                    {
                        Name = $"№{roomCount + i + 1}",
                        DateCreated = DateTimeOffset.UtcNow,
                        Deleted = false,
                        IsActive = true,
                        GroupId = existingRoomGroup.Id,
                        Id = Guid.NewGuid(),
                    };

                    await _roomRepository.AddAsync(room);
                }
            }

            //обновление атрибутов для группы комнат
            var comfortAttributes = request.ComfortAttributes.Select(a => new RoomAttribute
            {
                Id = a.RoomAttributeId is null ? Guid.NewGuid() : a.RoomAttributeId.Value,
                RoomGroupId = existingRoomGroup.Id,
                AttributeId = a.AttributeId,
                IsActive = a.IsActive,
                DateCreated = DateTimeOffset.UtcNow,
            }).ToList();

            var foodAttributes = request.FoodAttributes.Select(a => new RoomAttribute
            {
                Id = a.RoomAttributeId is null ? Guid.NewGuid() : a.RoomAttributeId.Value,
                RoomGroupId = existingRoomGroup.Id,
                AttributeId = a.AttributeId,
                IsActive = a.IsActive,
                DateCreated = DateTimeOffset.UtcNow,
            }).ToList();

            var bathroomAttributes = request.BathroomAttributes.Select(a => new RoomAttribute
            {
                Id = a.RoomAttributeId is null ? Guid.NewGuid() : a.RoomAttributeId.Value,
                RoomGroupId = existingRoomGroup.Id,
                AttributeId = a.AttributeId,
                IsActive = a.IsActive,
                DateCreated = DateTimeOffset.UtcNow,
            }).ToList();

            var mappedAttributes = comfortAttributes.Concat(foodAttributes).Concat(bathroomAttributes);

            foreach (var attr in mappedAttributes)
            {
                var existingAttribute = await _roomAttributeRepository.GetByIdAsync(attr.Id);
                if (existingAttribute is not null)
                {
                    existingAttribute.IsActive = attr.IsActive;
                    _roomAttributeRepository.Update(existingAttribute);
                }
                else
                {
                    await _roomAttributeRepository.AddAsync(attr);
                }
            }

            await _unitOfWork.SaveAsync();
            _logger.LogInformation("Группа комнат {@id} была обновлена", request.Id);
        }
    }
}
