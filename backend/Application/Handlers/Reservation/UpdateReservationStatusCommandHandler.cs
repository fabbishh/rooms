using Application.Commands;
using Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers.Reservation
{
    public class UpdateReservationStatusCommandHandler : IRequestHandler<UpdateReservationStatusCommand>
    {
        private readonly IRoomReservationRepository _roomReservationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateReservationStatusCommandHandler> _logger;
        public UpdateReservationStatusCommandHandler(
            IRoomReservationRepository roomReservationRepository, 
            IUnitOfWork unitOfWork,
            ILogger<UpdateReservationStatusCommandHandler> logger
            )
        {
            _roomReservationRepository = roomReservationRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Handle(UpdateReservationStatusCommand request, CancellationToken cancellationToken)
        {
            var existingReservation = await _roomReservationRepository.GetByIdAsync(request.Id);
            if (existingReservation is null)
            {
                return;
            }

            existingReservation.Status = request.Status;
            existingReservation.SanatoriumAdminComment = request.Comment;

            _roomReservationRepository.Update(existingReservation);
            await _unitOfWork.SaveAsync();
            _logger.LogInformation("Статус брони {@reservationId} изменен на '{@status}'", existingReservation.Id, existingReservation.Status);
        }
    }
}
