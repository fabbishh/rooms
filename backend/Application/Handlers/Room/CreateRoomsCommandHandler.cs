using Application.Commands;
using Application.Exceptions;
using Application.Services;
using Domain.Common;
using Domain.Enums;
using HousingReservation.Domain.Entities;
using HousingReservation.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Application.Handlers
{
    internal class CreateRoomsCommandHandler : IRequestHandler<CreateRoomsCommand>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomGroupRepository _roomGroupRepository;
        private readonly IPhotoManager _photoManager;
        private readonly IRoomAttributeRepository _roomAttributeRepository;
        private readonly IPhotoRepository _photoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateRoomsCommandHandler> _logger;

        public CreateRoomsCommandHandler(
            IRoomRepository roomRepository,
            IRoomGroupRepository roomGroupRepository,
            IPhotoManager photoManager,
            IRoomAttributeRepository roomAttributeRepository,
            IPhotoRepository photoRepository,
            IUnitOfWork unitOfWork,
            ILogger<CreateRoomsCommandHandler> logger)
        {
            _roomRepository = roomRepository;
            _roomGroupRepository = roomGroupRepository;
            _photoManager = photoManager;
            _roomAttributeRepository = roomAttributeRepository;
            _photoRepository = photoRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Handle(CreateRoomsCommand request, CancellationToken cancellationToken)
        {
            var requestName = request?.Name?.Trim();
            if (!requestName.IsNullOrEmpty())
            {
                var existingRoom = (await _roomRepository.FindAsync(r => r.Name == requestName)).FirstOrDefault();
                if (existingRoom != null)
                {
                    throw new RoomExistsException(existingRoom.Name);
                }
            }

            //создание группы для комнат
            var roomGroup = new RoomGroup
            {
                Id = Guid.NewGuid(),
                DateCreated = DateTimeOffset.UtcNow,
                Name = requestName,
                IsActive = true,
                Deleted = false,
                PricePerNight = request.PricePerNight,
                BedroomCount = request.BedroomCount,
                DoubleBedCount = request.DoubleBedCount,
                SingleBedCount = request.SingleBedCount,
                SanatoriumId = request.SanatoriumId,
                Description = request.Description,
                MinDaysReservation = request.MinDaysReservation,
                RoomType = (RoomType)request.RoomType,
                HousingType = (HousingType)request.HousingType,
                Status = request.Status,
            };
            await _roomGroupRepository.AddAsync(roomGroup);

            //добавление фото для группы комнат
            if (request.Photos is not null && request.Photos.Any())
            {
                var savedOnDiskPhotos = _photoManager.SavePhotoOnDisk(request.Photos);

                foreach (var photo in savedOnDiskPhotos)
                {
                    photo.RoomGroupId = roomGroup.Id;
                    await _photoRepository.AddAsync(photo);
                }
            }

            //добавление комнат
            for (int i = 0; i < request.SameRoomCount; i++)
            {
                var room = new Room
                {
                    Id = Guid.NewGuid(),
                    Name = $"№{i+1}",
                    GroupId = roomGroup.Id,
                    DateCreated = DateTimeOffset.UtcNow,
                    IsActive = true,
                };
                await _roomRepository.AddAsync(room);

                await _unitOfWork.SaveAsync();
            }

            //создание атрибутов для группы комнат
            var comfortAttributes = request.ComfortAttributes.Select(a => new RoomAttribute
            {
                Id = a.RoomAttributeId is null ? Guid.NewGuid() : a.RoomAttributeId.Value,
                RoomGroupId = roomGroup.Id,
                AttributeId = a.AttributeId,
                IsActive = a.IsActive,
                DateCreated = DateTimeOffset.UtcNow,
            }).ToList();

            var foodAttributes = request.FoodAttributes.Select(a => new RoomAttribute
            {
                Id = a.RoomAttributeId is null ? Guid.NewGuid() : a.RoomAttributeId.Value,
                RoomGroupId = roomGroup.Id,
                AttributeId = a.AttributeId,
                IsActive = a.IsActive,
                DateCreated = DateTimeOffset.UtcNow,
            }).ToList();

            var bathroomAttributes = request.BathroomAttributes.Select(a => new RoomAttribute
            {
                Id = a.RoomAttributeId is null ? Guid.NewGuid() : a.RoomAttributeId.Value,
                RoomGroupId = roomGroup.Id,
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
            _logger.LogInformation("Группа комнат {@id} была добавлена", roomGroup.Id);
        }
    }
}
