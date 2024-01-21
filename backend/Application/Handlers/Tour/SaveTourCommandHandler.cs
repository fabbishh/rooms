using Application.Commands;
using Application.Models;
using Application.Services;
using Domain.Common;
using Domain.Entities;
using HousingReservation.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Application.Handlers
{
    public class SaveTourCommandHandler : IRequestHandler<SaveTourCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITourRepository _tourRepository;
        private readonly ITourDateRepository _tourDateRepository;
        private readonly ILogger<SaveTourCommandHandler> _logger;
        private readonly IPhotoManager _photoManager;
        private readonly IPhotoRepository _photoRepository;
        private readonly ITourSeasonRepository _tourSeasonRepository;
        private readonly ITourTourSeasonRepository _tourTourSeasonRepository;

        public SaveTourCommandHandler(
            ITourRepository tourRepository,
            ITourDateRepository tourDateRepository,
            IUnitOfWork unitOfWork,
            ILogger<SaveTourCommandHandler> logger,
            IPhotoManager photoManager,
            IPhotoRepository photoRepository,
            ITourSeasonRepository tourSeasonRepository,
            ITourTourSeasonRepository tourTourSeasonRepository)
        {
            _tourRepository = tourRepository;
            _tourDateRepository = tourDateRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _photoManager = photoManager;
            _photoRepository = photoRepository;
            _tourSeasonRepository = tourSeasonRepository;
            _tourTourSeasonRepository = tourTourSeasonRepository;
        }

        public async Task Handle(SaveTourCommand request, CancellationToken cancellationToken)
        {
            Tour? tour = null;
            if (request.Id.HasValue)
            {
                tour = await _tourRepository.GetByIdAsync(request.Id.Value);
                if (tour == null)
                {
                    throw new InvalidOperationException("Обновление не удалось, тур не найден");
                }

                tour.Name = request.Name;
                tour.PriceByTourist = request.PriceByTourist;
                tour.PriceByGroup = request.PriceByGroup;
                tour.IsActive = request.IsActive;
                tour.Days = request.Days;
                tour.TouristCountFrom = request.TouristCountFrom;
                tour.TouristCountTo = request.TouristCountTo;
                tour.Description = request.Description;
                tour.TypeId = request.Type;
                tour.SubjectId = request.Subject;
                tour.Status = request.Status.HasValue ? request.Status.Value : Domain.Enums.AdminRequestStatus.Pending;

                _tourRepository.Update(tour);

                //добавление фото
                await AddTourPhotos(request.Photos, tour.Id);

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

                await UpdateDates(request.StartDates, tour);
                await SaveSeasons(request.Seasons, tour.Id);

                await _unitOfWork.SaveAsync();
                _logger.LogInformation("Тур {@id} был обновлен", tour.Id);

            }
            else
            {
                tour = new Tour
                {
                    Id = Guid.NewGuid(),
                    DateCreated = DateTimeOffset.UtcNow,
                    IsActive = request.IsActive,
                    Name = request.Name,
                    PriceByGroup = request.PriceByGroup,
                    PriceByTourist = request.PriceByTourist,
                    TourAgencyId = request.TourAgencyId,
                    Days = request.Days,
                    TouristCountFrom = request.TouristCountFrom,
                    TouristCountTo = request.TouristCountTo,
                    Description = request.Description,
                    TypeId = request.Type,
                    SubjectId = request.Subject,
                    Status = request.Status.HasValue ? request.Status.Value : Domain.Enums.AdminRequestStatus.Pending
                };

                await _tourRepository.AddAsync(tour);

                await AddTourPhotos(request.Photos, tour.Id);
                await UpdateDates(request.StartDates, tour);
                await SaveSeasons(request.Seasons, tour.Id);

                await _unitOfWork.SaveAsync();

                _logger.LogInformation("Тур {@id} был создан", tour.Id);
            }
        }

        private async Task SaveSeasons(List<int> tourSeasons, Guid tourId)
        {
            var seasons = await _tourSeasonRepository.FindAsync(s => tourSeasons.Contains(s.Value));
            if(seasons is null || !seasons.Any())
            {
                return;
            }

            //удаление существующих сезонов, привязанных к туру
            var existingTourSeasons = await _tourTourSeasonRepository.FindAsync(s => s.TourId == tourId);
            foreach (var tourSeason in existingTourSeasons)
            {
                _tourTourSeasonRepository.SetDeletedFlag(tourSeason);
            }

            //добавление новой привязки сезонов
            
            foreach (var season in seasons)
            {
                var newSeason = new TourTourSeason
                {
                    Id = Guid.NewGuid(),
                    DateCreated = DateTimeOffset.UtcNow,
                    Deleted = false,
                    IsActive = true,
                    TourSeasonId = season.Id,
                    TourId = tourId,
                };

                await _tourTourSeasonRepository.AddAsync(newSeason);
            }
        }

        private async Task AddTourPhotos(List<IFormFile>? photos, Guid tourId)
        {
            //добавление фото для тура
            if (photos is not null && photos.Any())
            {
                var savedOnDiskPhotos = _photoManager.SavePhotoOnDisk(photos!);

                foreach (var photo in savedOnDiskPhotos)
                {
                    photo.TourId = tourId;
                    await _photoRepository.AddAsync(photo);
                }
            }
        }

        private async Task UpdateDates(List<TourStartDate>? startDates, Tour? tour)
        {
            if (startDates is null || !startDates.Any() || tour is null) 
            {
                return;
            }

            var datesToAdd = startDates.Where(d => !d.Id.HasValue).Select(d => new TourDate
            {
                Id = Guid.NewGuid(),
                StartDate = d.StartDate,
                DateCreated = DateTimeOffset.UtcNow,
                IsActive = tour.IsActive,
                TourId = tour.Id,
            });

            foreach (var date in datesToAdd)
            {
                await _tourDateRepository.AddAsync(date);
            }

            var existingDateIds = startDates.Where(d => d.Id.HasValue).Select(d => d.Id);

            var datesToRemove = await _tourDateRepository.FindAsync(d => d.TourId == tour.Id && !existingDateIds.Contains(d.Id));

            foreach (var date in datesToRemove)
            {
                _tourDateRepository.SetDeletedFlag(date);
            }
        }
    }
}
