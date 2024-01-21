using Application.Models;
using Application.Queries;
using Domain.Common;
using MediatR;

namespace Application.Handlers.Reservation
{
    public class GetReservationQueryHandler : IRequestHandler<GetReservationQuery, ReservationDetailsModel?>
    {
        private readonly IRoomReservationRepository _roomReservationRepository;

        public GetReservationQueryHandler(IRoomReservationRepository roomReservationRepository)
        {
            _roomReservationRepository = roomReservationRepository;
        }

        public async Task<ReservationDetailsModel?> Handle(GetReservationQuery request, CancellationToken cancellationToken)
        {
            var reservation = await _roomReservationRepository.GetByIdAsync(request.ReservationId);
            if (reservation == null)
            {
                return null;
            }

            var reservationDetails = new ReservationDetailsModel
            {
                Id = reservation.Id,
                RoomName = $"{reservation.Room.Group?.Name} {reservation.Room.Name}",
                Status = reservation.Status,
                SanatoriumAdminComment = reservation.SanatoriumAdminComment,
                Author = new AuthorModel
                {
                    Email = reservation.User?.Email,
                    PhoneNumber = reservation.PhoneNumber,
                    FirstName = reservation.User?.FirstName,
                    LastName = reservation.User?.LastName,
                    Patronymic = reservation.User?.Patronymic,
                },
                Guests = reservation.Guests.Select(g => new GuestModel
                {
                    Firstname = g.Firstname,
                    Lastname = g.Lastname,
                    Patronymic = g.Patronymic,
                    Id = g.Id,
                }).ToList()
            };

            return reservationDetails;
        }
    }
}
