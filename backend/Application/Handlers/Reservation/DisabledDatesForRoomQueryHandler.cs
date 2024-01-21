using Application.Models;
using Application.Queries;
using Domain.Common;
using MediatR;

namespace Application.Handlers
{
    public class DisabledDatesForRoomQueryHandler : IRequestHandler<DisabledDatesForRoomQuery, List<DateRangeModel>>
    {
        private readonly IRoomReservationRepository _reservationRepository;

        public DisabledDatesForRoomQueryHandler(IRoomReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<List<DateRangeModel>> Handle(DisabledDatesForRoomQuery request, CancellationToken cancellationToken)
        {
            var roomReservations = await _reservationRepository
                .FindAsync(r =>
                        r.RoomId == request.RoomId
                        && r.Status == Domain.Enums.AdminRequestStatus.Confirmed
                        && r.EndDate.Date >= DateTimeOffset.UtcNow.Date
                        );

            var disabledDateRanges = roomReservations.Select(r => new DateRangeModel
            {
                Start = r.StartDate,
                End = r.EndDate.AddDays(-1),
            }).ToList();

            return disabledDateRanges;
        }
    }
}
