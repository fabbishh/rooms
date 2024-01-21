using Application.Commands;
using Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers
{
    public class DeleteUsersCommandHandler : IRequestHandler<DeleteUsersCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<DeleteUsersCommand> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoomReservationRepository _roomReservationRepository;


        public DeleteUsersCommandHandler(
            IUnitOfWork unitOfWork,
            ILogger<DeleteUsersCommand> logger,
            IUserRepository userRepository,
            IRoomReservationRepository roomReservationRepository
            )
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _userRepository = userRepository;
            _roomReservationRepository = roomReservationRepository;
        }
        public async Task Handle(DeleteUsersCommand request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.FindAsync(u => request.Ids.Contains(u.Id));

            if (users == null || !users.Any())
            {
                return;
            }

            foreach(var user in users)
            {
                _userRepository.SetDeletedFlag(user);
            }

            var reservations = await _roomReservationRepository.FindAsync(rr => users.Select(r => r.Id).Contains(rr.UserId));
            foreach (var res in reservations)
            {
                _roomReservationRepository.SetDeletedFlag(res);
            }

            await _unitOfWork.SaveAsync();
            _logger.LogInformation("Удалены пользователи: {@ids}", request.Ids);
        }
    }
}
