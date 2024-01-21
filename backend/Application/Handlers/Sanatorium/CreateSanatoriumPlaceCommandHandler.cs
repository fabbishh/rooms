using Application.Commands;
using AutoMapper;
using Domain.Common;
using HousingReservation.Domain.Common;
using HousingReservation.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers
{
    internal class CreateSanatoriumPlaceCommandHandler : IRequestHandler<CreateSanatoriumPlaceCommand>
    {
        private readonly IMapper _mapper;
        private readonly ISanatoriumPlaceRepository _sanatoriumPlaceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateSanatoriumPlaceCommandHandler> _logger;

        public CreateSanatoriumPlaceCommandHandler(
            IMapper mapper, 
            ISanatoriumPlaceRepository sanatoriumPlaceRepository, 
            IUnitOfWork unitOfWork,
            ILogger<CreateSanatoriumPlaceCommandHandler> logger
            )
        {
            _mapper = mapper;
            _sanatoriumPlaceRepository = sanatoriumPlaceRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task Handle(CreateSanatoriumPlaceCommand request, CancellationToken cancellationToken)
        {
            var sanatoriumPlace = _mapper.Map<SanatoriumPlace>(request);

            await _sanatoriumPlaceRepository.AddAsync(sanatoriumPlace);

            await _unitOfWork.SaveAsync();
            _logger.LogInformation("Место {@placeId} было привязано к санаторию {@sanatoriumId}", request.PlaceId, request.SanatoriumId);
        }
    }
}
