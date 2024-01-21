using Application.Commands;
using Application.Services;
using AutoMapper;
using Domain.Common;
using HousingReservation.Domain.Common;
using HousingReservation.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Application.Handlers
{
    public class SavePlaceCommandHandler : IRequestHandler<SavePlaceCommand>
    {
        private readonly IMapper _mapper;
        private readonly IPlaceRepository _placeRepository;
        private readonly IPhotoRepository _photoRepository;
        private readonly IPhotoManager _photoManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SavePlaceCommandHandler> _logger;
        public SavePlaceCommandHandler(
            IMapper mapper, 
            IPlaceRepository placeRepository, 
            IPhotoManager photoManager, 
            IPhotoRepository photoRepository,
            IUnitOfWork unitOfWork,
            ILogger<SavePlaceCommandHandler> logger)
        {
            _mapper = mapper;
            _placeRepository = placeRepository;
            _photoManager = photoManager;
            _unitOfWork = unitOfWork;
            _photoRepository = photoRepository;
            _logger = logger;
        }
        public async Task Handle(SavePlaceCommand request, CancellationToken cancellationToken)
        {
            if(request.Id.HasValue)
            {
                var place = await _placeRepository.GetByIdAsync(request.Id.Value);
                if (place == null)
                {
                    throw new InvalidOperationException("Обновление не удалось, место не найдено");
                }

                var existingPlace = await _placeRepository.FindOneAsync(p => p.Id != request.Id && p.Name == request.Name);
                if (existingPlace is not null) 
                {
                    throw new InvalidOperationException($"Место с названием '{request.Name}' уже существует");
                }

                place.Name = request.Name;
                place.Description = request.Description;
                place.SubjectId = request.SubjectId;

                _placeRepository.Update(place);

                //добавление фото для группы комнат
                await AddPhotos(request.Photos, place.Id);

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

                await _unitOfWork.SaveAsync();
                _logger.LogInformation("Место {@id} было обновлено", place.Id);
            } else
            {
                var existingPlace = await _placeRepository.FindOneAsync(p => p.Id != request.Id && p.Name == request.Name);
                if (existingPlace is not null)
                {
                    throw new InvalidOperationException($"Место с названием '{request.Name}' уже существует");
                }
                var mappedPlace = _mapper.Map<Place>(request);

                await _placeRepository.AddAsync(mappedPlace);

                await AddPhotos(request.Photos, mappedPlace.Id);

                await _unitOfWork.SaveAsync();

                _logger.LogInformation("Место {@id} было создано", mappedPlace.Id);
            }
           
        }

        private async Task AddPhotos(List<IFormFile>? photos, Guid placeId)
        {
            //добавление фото
            if (photos is not null && photos.Any())
            {
                var savedOnDiskPhotos = _photoManager.SavePhotoOnDisk(photos!);

                foreach (var photo in savedOnDiskPhotos)
                {
                    photo.PlaceId = placeId;
                    await _photoRepository.AddAsync(photo);
                }
            }
        }
    }
}
