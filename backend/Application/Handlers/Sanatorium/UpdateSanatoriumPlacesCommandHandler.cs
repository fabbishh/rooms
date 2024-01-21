using Application.Commands;
using AutoMapper;
using Domain.Common;
using HousingReservation.Domain.Common;
using HousingReservation.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers
{
    public class UpdateSanatoriumPlacesCommandHandler : IRequestHandler<UpdateSanatoriumPlacesCommand>
    {
        private readonly IMapper _mapper;
        private readonly ISanatoriumPlaceRepository _sanatoriumPlaceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateSanatoriumPlacesCommandHandler> _logger;

        public UpdateSanatoriumPlacesCommandHandler(
            IMapper mapper, 
            ISanatoriumPlaceRepository sanatoriumPlaceRepository, 
            IUnitOfWork unitOfWork,
            ILogger<UpdateSanatoriumPlacesCommandHandler> logger)
        {
            _mapper = mapper;
            _sanatoriumPlaceRepository = sanatoriumPlaceRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Handle(UpdateSanatoriumPlacesCommand request, CancellationToken cancellationToken)
        {
            var existingSanatoriumPlaces = await _sanatoriumPlaceRepository.FindAsync(s => s.SanatoriumId == request.SanatoriumId);

            foreach (var deletedSanatoriumPlaces in existingSanatoriumPlaces)
            {
                _sanatoriumPlaceRepository.Remove(deletedSanatoriumPlaces);
            }

            foreach (var newSanatoriumPlace in request.SanatoriumPlaces)
            {

                await _sanatoriumPlaceRepository.AddAsync(new SanatoriumPlace
                {
                    Id = Guid.NewGuid(),
                    SanatoriumId = request.SanatoriumId,
                    PlaceId = newSanatoriumPlace.PlaceId,
                    IsActive = true,
                });
            }

            await _unitOfWork.SaveAsync();
            _logger.LogInformation("Список привязанных мест к санаторию {@id} был обновлен", request.SanatoriumId);
        }
    }
}
