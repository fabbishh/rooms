using Application.Commands;
using Application.Exceptions;
using Domain.Common;
using Domain.Entities;
using Domain.Enums;
using HousingReservation.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers.Reservation
{
    internal class CreateUnathorizedReservationCommandHandler : IRequestHandler<CreateUnathorizedReservationCommand>
    {
        private readonly IRoomReservationRepository _roomReservationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IGuestsRepository _guestsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateUnathorizedReservationCommandHandler> _logger;
        public CreateUnathorizedReservationCommandHandler(
            IRoomReservationRepository roomReservationRepository,
            IUserRepository userRepository,
            IGuestsRepository guestsRepository,
            IUnitOfWork unitOfWork,
            ILogger<CreateUnathorizedReservationCommandHandler> logger
            )
        {
            _guestsRepository = guestsRepository;
            _userRepository = userRepository;
            _roomReservationRepository = roomReservationRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task Handle(CreateUnathorizedReservationCommand request, CancellationToken cancellationToken)
        {
            var existingReservations = await _roomReservationRepository
                .FindAsync(r =>
                    r.RoomId == request.RoomId
                    && r.Status == AdminRequestStatus.Confirmed
                    && request.StartDate < r.EndDate && request.EndDate > r.EndDate);

            if (existingReservations.Any())
            {
                throw new OverlappingReservationException();
            }

            var existingUser = await _userRepository.FindOneAsync(u => u.Email == request.Email);

            if (existingUser == null)
            {
                existingUser = new User
                {
                    Id = Guid.NewGuid(),
                    DateCreated = DateTimeOffset.UtcNow,
                    Deleted = false,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Patronymic = request.Patronymic,
                    IsEmailConfirmed = false,
                    IsPhoneNumberConfirmed = false,
                    IsActive = true,
                    Role = Role.User,
                };

                await _userRepository.AddAsync(existingUser);
                await _unitOfWork.SaveAsync();
                _logger.LogInformation("Создан новый пользователь {@email}", existingUser.Email);
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
                UserId = existingUser.Id,
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
