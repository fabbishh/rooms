using Application.Commands;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers.FavouriteSanatoriums
{
    internal class AddFavouriteSanatoriumCommandHandler : IRequestHandler<AddFavouriteSanatoriumCommand>
    {
        private readonly IFavouriteSanatoriumRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AddFavouriteSanatoriumCommandHandler> _logger;

        public AddFavouriteSanatoriumCommandHandler(IFavouriteSanatoriumRepository repository, ILogger<AddFavouriteSanatoriumCommandHandler> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AddFavouriteSanatoriumCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repository.FindOneAsync(fs => fs.UserId == request.UserId && fs.SanatoriumId == request.SanatoriumId);
            if (existing is not null)
            {
                throw new InvalidOperationException();
            }

            var favouriteSanatorium = new FavouriteSanatorium
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                SanatoriumId = request.SanatoriumId,
                DateCreated = DateTimeOffset.UtcNow,
                Deleted = false,
                IsActive = true,
            };

            await _repository.AddAsync(favouriteSanatorium);
            await _unitOfWork.SaveAsync();

            _logger.LogInformation("Санаторий {@sanatoriumId} был добавлен в избранное пользователя {@userId}", favouriteSanatorium.SanatoriumId, favouriteSanatorium.UserId);
        }
    }
}
