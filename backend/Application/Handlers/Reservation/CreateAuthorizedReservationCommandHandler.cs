using Application.Commands;
using Application.Exceptions;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Enums;
using HousingReservation.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers
{
    public class CreateAuthorizedReservationCommandHandler : IRequestHandler<CreateAuthorizedReservationCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRoomReservationRepository _roomReservationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IGuestsRepository _guestsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateAuthorizedReservationCommandHandler> _logger;

        public CreateAuthorizedReservationCommandHandler(
            IMapper mapper, 
            IRoomReservationRepository roomReservationRepository,
            IUserRepository userRepository,
            IGuestsRepository guestsRepository,
            IUnitOfWork unitOfWork,
            ILogger<CreateAuthorizedReservationCommandHandler> logger)
        {
            _mapper = mapper;
            _roomReservationRepository = roomReservationRepository;
            _userRepository = userRepository;
            _guestsRepository = guestsRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task Handle(CreateAuthorizedReservationCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByIdAsync(request.UserId);
            if (existingUser == null)
            {
                throw new UserNotFoundException(request.UserId.ToString());
            }

            var existingReservations = await _roomReservationRepository
                .FindAsync(r =>
                    r.RoomId == request.RoomId
                    && r.Status == AdminRequestStatus.Confirmed
                    && request.StartDate < r.EndDate && request.EndDate > r.EndDate);

            if (existingReservations.Any())
            {
                throw new OverlappingReservationException();
            }

            var reservation = new RoomReservation
            {
                Id = Guid.NewGuid(),
                DateCreated = DateTime.UtcNow,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                GuestComment = request.GuestComment,
                IsActive = true,
                Status = AdminRequestStatus.Pending,
                UserId = request.UserId,
                RoomId = request.RoomId,
                AdultGuestsCount = request.AdultGuestsCount,
                ChildGuestsCount = request.ChildGuestsCount,
                PhoneNumber = request.PhoneNumber,
            };

            await _roomReservationRepository.AddAsync(reservation);

            if (request.Guests != null)
            {
                foreach (var guest in request.Guests)
                {
                    var mappedGuest = new Guest
                    {
                        Id = Guid.NewGuid(),
                        Firstname = guest.Firstname,
                        Lastname = guest.Lastname,
                        Patronymic = guest.Patronymic,
                        IsActive = true,
                        DateCreated = DateTime.UtcNow,
                        RoomReservationId = reservation.Id,
                    };

                    await _guestsRepository.AddAsync(mappedGuest);
                }
            }

            existingUser.FirstName = request.FirstName;
            existingUser.LastName = request.LastName;
            existingUser.Patronymic = request.Patronymic;
            existingUser.PhoneNumber = request.PhoneNumber;

            _userRepository.Update(existingUser);

            await _unitOfWork.SaveAsync();
            _logger.LogInformation("Бронь в номере {@roomId} была отправлена на рассмотрение", request.RoomId);
        }
    }
}
