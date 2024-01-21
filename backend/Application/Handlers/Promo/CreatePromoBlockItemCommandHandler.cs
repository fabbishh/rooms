using Application.Commands;
using Application.Exceptions;
using Domain.Common;
using HousingReservation.Domain.Entities;
using HousingReservation.Domain.Sanatoriums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers
{
    internal class CreatePromoBlockItemCommandHandler : IRequestHandler<CreatePromoBlockItemCommand>
    {
        private readonly IPromoBlockItemRepository _promoBlockItemRepository;
        private readonly IPromoBlockRepository _promoBlockRepository;
        private readonly ISanatoriumRepository _sanatoriumRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly ITourRepository _tourRepository;
        private readonly ITourAgencyRepository _tourAgencyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreatePromoBlockItemCommandHandler> _logger;

        public CreatePromoBlockItemCommandHandler(
            IPromoBlockItemRepository promoBlockItemRepository,
            IPromoBlockRepository promoBlockRepository,
            ISanatoriumRepository sanatoriumRepository,
            IRoomRepository roomRepository,
            ITourRepository tourRepository,
            ITourAgencyRepository tourAgencyRepository,
            IUnitOfWork unitOfWork,
            ILogger<CreatePromoBlockItemCommandHandler> logger)
        {
            _promoBlockItemRepository = promoBlockItemRepository;
            _promoBlockRepository = promoBlockRepository;
            _roomRepository = roomRepository;
            _tourRepository = tourRepository;
            _sanatoriumRepository = sanatoriumRepository;
            _tourAgencyRepository = tourAgencyRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Handle(CreatePromoBlockItemCommand request, CancellationToken cancellationToken)
        {
            if (request.HasMultipleValues())
            {
                throw new InvalidOperationException("Попытка добавить несколько элементов в промо-блок");
            }

            var existingPromoBlock = await _promoBlockRepository.GetByIdAsync(request.PromoBlockId);
            if (existingPromoBlock == null)
            {
                throw new PromoBlockNotFoundException(request.PromoBlockId);
            }

            if (request.SanatoriumId.HasValue)
            {
                var existingSanatorium = await _sanatoriumRepository.GetByIdAsync(request.SanatoriumId.Value);
                if (existingSanatorium == null)
                {
                    throw new SanatoriumNotFoundException(request.SanatoriumId.Value);
                }
            } 
            else if (request.RoomId.HasValue)
            {
                var existingRoom = await _roomRepository.GetByIdAsync(request.RoomId.Value);
                if (existingRoom == null)
                {
                    throw new RoomNotFoundException(request.RoomId.Value);
                }
            }

            else if (request.TourAgencyId.HasValue)
            {
                var existingTourAgency = await _tourAgencyRepository.GetByIdAsync(request.TourAgencyId.Value);
                if (existingTourAgency == null)
                {
                    throw new SanatoriumNotFoundException(request.TourAgencyId.Value);
                }
            }

            else if (request.TourId.HasValue)
            {
                var existingTour = await _tourRepository.GetByIdAsync(request.TourId.Value);
                if (existingTour == null)
                {
                    throw new SanatoriumNotFoundException(request.TourId.Value);
                }
            }
            else
            {
                throw new InvalidOperationException("Не предоставлен объект для промо");
            }

            await _promoBlockItemRepository.AddAsync(new PromoBlockItem
            {
                Id = Guid.NewGuid(),
                DateCreated = DateTime.UtcNow,
                PromoBlockId = request.PromoBlockId,
                IsActive = true,
                SanatoriumId = request.SanatoriumId,
                TourAgencyId = request.TourAgencyId,
                RoomId = request.RoomId,
                TourId = request.TourId,
                AdminRequestStatus = Domain.Enums.AdminRequestStatus.Pending
            });

            await _unitOfWork.SaveAsync();
            if (request.SanatoriumId.HasValue)
            {
                _logger.LogInformation("Запрос на добавление санатория {@id} в промоблок", request.SanatoriumId);
            }
            if (request.RoomId.HasValue)
            {
                _logger.LogInformation("Запрос на добавление жилья {@id} в промоблок", request.RoomId);
            }
            if (request.TourAgencyId.HasValue)
            {
                _logger.LogInformation("Запрос на добавление турагенства {@id} в промоблок", request.TourAgencyId);
            }
            if (request.TourId.HasValue)
            {
                _logger.LogInformation("Запрос на добавление тура {@id} в промоблок", request.TourId);
            }


        }
    }
}
