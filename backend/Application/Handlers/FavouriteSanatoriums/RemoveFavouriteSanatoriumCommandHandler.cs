using Application.Commands;
using Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers.FavouriteSanatoriums
{
    internal class RemoveFavouriteSanatoriumCommandHandler : IRequestHandler<RemoveFavouriteSanatoriumCommand>
    {
        private readonly IFavouriteSanatoriumRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AddFavouriteSanatoriumCommandHandler> _logger;

        public RemoveFavouriteSanatoriumCommandHandler(IFavouriteSanatoriumRepository repository, ILogger<AddFavouriteSanatoriumCommandHandler> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveFavouriteSanatoriumCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repository.FindOneAsync(fs => fs.UserId == request.UserId && fs.SanatoriumId == request.SanatoriumId);
            if (existing is null)
            {
                _logger.LogInformation("Попытка убрать санаторий {@sanatoriumId} из избранного пользователя {@userId}. Запись не была найдена", request.SanatoriumId, request.UserId);
                return;
            }

            _repository.Remove(existing);
            await _unitOfWork.SaveAsync();

            _logger.LogInformation("Санаторий {@sanatoriumId} был убран из избранного пользователя {@userId}", existing.SanatoriumId, existing.UserId);
        }
    }
}
