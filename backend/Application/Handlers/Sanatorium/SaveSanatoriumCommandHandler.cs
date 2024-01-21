using Application.Commands;
using Application.Services;
using AutoMapper;
using Domain.Common;
using HousingReservation.Domain.Entities;
using HousingReservation.Domain.Sanatoriums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Security.Principal;

namespace Application.Handlers
{
    public class SaveSanatoriumCommandHandler : IRequestHandler<SaveSanatoriumCommand, Guid>
    {
        private readonly ISanatoriumRepository _sanatoriumRepository;
        private readonly ISanatoriumAttributeRepository _sanatoriumAttributeRepository;
        private readonly IAttributeRepository _attributeRepository;
        private readonly IPhotoRepository _photoRepository;
        private readonly IPhotoManager _photoManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SaveSanatoriumCommandHandler> _logger;
        public SaveSanatoriumCommandHandler(
            ISanatoriumRepository sanatoriumRepository,
            IPhotoRepository photoRepository,
            IMapper mapper,
            IPhotoManager photoManager,
            ISanatoriumAttributeRepository sanatoriumAttributeRepository,
            IAttributeRepository attributeRepository,
            IUnitOfWork unitOfWork,
            ILogger<SaveSanatoriumCommandHandler> logger
            )
        {
            _sanatoriumRepository = sanatoriumRepository;
            _photoRepository = photoRepository;
            _mapper = mapper;
            _photoManager = photoManager;
            _sanatoriumAttributeRepository = sanatoriumAttributeRepository;
            _attributeRepository = attributeRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<Guid> Handle(SaveSanatoriumCommand request, CancellationToken cancellationToken)
        {
            var existingSanatorium = await _sanatoriumRepository.FindAsync(s => (s.Name == request.Name || s.Email == request.Email) && s.Id != request.Id);

            if(existingSanatorium.Any())
            {
                throw new InvalidOperationException("Санаторий с таким именем или email уже существует");
            }

            Sanatorium? sanatorium = null;
            if(!request.Id.HasValue)
            {
                sanatorium = _mapper.Map<Sanatorium>(request);

                var photoId = await SavePhotoAsync(request.Photo);
                sanatorium.PhotoId = photoId;

                await _sanatoriumRepository.AddAsync(sanatorium);

                var attributes = await _attributeRepository.FindAsync(a => a.AttributeGroup.Name == "SanatoriumComfort"
                                                                    || a.AttributeGroup.Name == "Service" || a.AttributeGroup.Name == "SanatoriumFood");
                foreach (var comfortAttribute in attributes)
                {
                    var sanatoriumAttribute = new SanatoriumAttribute
                    {
                        Id = Guid.NewGuid(),
                        AttributeId = comfortAttribute.Id,
                        DateCreated = DateTimeOffset.UtcNow,
                        IsActive = false,
                        SanatoriumId = sanatorium.Id
                    };

                    await _sanatoriumAttributeRepository.AddAsync(sanatoriumAttribute);
                }

                await _unitOfWork.SaveAsync();

                _logger.LogInformation("Санаторий {@sanatorium} был создан.", sanatorium);
            }
            else
            {
                sanatorium = await _sanatoriumRepository.GetByIdAsync(request.Id.Value);

                if (sanatorium is null)
                {
                    throw new InvalidOperationException("Ошибка обновления санатория");
                }

                var photoId = await SavePhotoAsync(request.Photo);

                if (photoId is not null && sanatorium.PhotoId is not null)
                {
                    var existingPhoto = await _photoRepository.GetByIdAsync(sanatorium.PhotoId.Value);
                    if(existingPhoto is not null)
                    {
                        _photoManager.DeletePhotosFromDisk(new List<Photo> { existingPhoto });
                        _photoRepository.Remove(existingPhoto);
                    }
                    
                }
                if (photoId is not null)
                {
                    sanatorium.PhotoId = photoId;
                }

                sanatorium.Name = request.Name;
                sanatorium.Location = request.Location;
                sanatorium.CheckInTime = request.CheckInTime;
                sanatorium.CheckOutTime = request.CheckOutTime;
                sanatorium.Email = request.Email;
                sanatorium.TypeId = request.ObjectType;
                sanatorium.Season = request.Season;
                sanatorium.Status = request.Status;
                sanatorium.OwnerId = request.OwnerId;

                _sanatoriumRepository.Update(sanatorium);

                await _unitOfWork.SaveAsync();
                _logger.LogInformation("Санаторий {@Id} был обновлен.", sanatorium.Id);
            }

            
                
            return sanatorium.Id;
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
