using Application.Commands;
using Application.Exceptions;
using Application.Services;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using HousingReservation.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Application.Handlers
{
    internal class SaveTourAgencyCommandHandler : IRequestHandler<SaveTourAgencyCommand>
    {
        private readonly IMapper _mapper;
        private readonly ITourAgencyRepository _tourAgencyRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IPhotoManager _photoManager;
        private readonly IPhotoRepository _photoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SaveTourAgencyCommandHandler> _logger;

        public SaveTourAgencyCommandHandler(
            IMapper mapper,
            ITourAgencyRepository tourAgencyRepository,
            IContactRepository contactRepository,
            IPhotoManager photoManager,
            IPhotoRepository photoRepository,
            IUnitOfWork unitOfWork,
            ILogger<SaveTourAgencyCommandHandler> logger
        )
        {
            _mapper = mapper;
            _tourAgencyRepository = tourAgencyRepository;
            _contactRepository = contactRepository;
            _photoManager = photoManager;
            _photoRepository = photoRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Handle(SaveTourAgencyCommand request, CancellationToken cancellationToken)
        {
            var existingTourAgency = await _tourAgencyRepository.FindAsync(ta => ta.Name == request.Name && ta.Id != request.Id);

            if (existingTourAgency.Any())
            {
                throw new TourAgencyExistsException(request.Name);
            }

            if (!request.Id.HasValue) 
            {
                var tourAgency = _mapper.Map<TourAgency>(request);

                var photoId = await SavePhotoAsync(request.Logo);

                tourAgency.PhotoId = photoId;

                await _tourAgencyRepository.AddAsync(tourAgency);
                await _unitOfWork.SaveAsync();
                _logger.LogInformation("Турагентсво {@id} было создано", tourAgency.Id);
            } 
            else
            {
                var tourAgencyToUpdate = await _tourAgencyRepository.GetByIdAsync(request.Id.Value);

                if(tourAgencyToUpdate is null)
                {
                    throw new InvalidOperationException(request.Id.Value.ToString());
                }

                var photoId = await SavePhotoAsync(request.Logo);

                if (photoId is not null && tourAgencyToUpdate.PhotoId is not null)
                {
                    var existingPhoto = await _photoRepository.GetByIdAsync(tourAgencyToUpdate.PhotoId.Value);
                    if (existingPhoto is not null)
                    {
                        _photoManager.DeletePhotosFromDisk(new List<Photo> { existingPhoto });
                        _photoRepository.Remove(existingPhoto);
                    }
                }

                if (photoId is not null)
                {
                    tourAgencyToUpdate.PhotoId = photoId;
                }

                tourAgencyToUpdate.Id = request.Id.Value;
                tourAgencyToUpdate.Name = request.Name;
                tourAgencyToUpdate.Location = request.Location;
                tourAgencyToUpdate.Email = request.Email;
                tourAgencyToUpdate.Link = request.Link;
                tourAgencyToUpdate.Description = request.Description;
                tourAgencyToUpdate.Status = request.Status;

                _tourAgencyRepository.Update(tourAgencyToUpdate);
                await _unitOfWork.SaveAsync();
                _logger.LogInformation("Турагентсво {@id} было обновлено", tourAgencyToUpdate.Id);
            }

            
        }

        private async Task<Guid?> SavePhotoAsync(IFormFile? photo)
        {
            if (photo is null)
            {
                return null;
            }

            var savedPhotos = _photoManager.SavePhotoOnDisk(new List<IFormFile> { photo });
            if (!savedPhotos.Any())
            {
                return null;
            }

            await _photoRepository.AddAsync(savedPhotos.First());

            return savedPhotos.First().Id;
        }
    }
}
