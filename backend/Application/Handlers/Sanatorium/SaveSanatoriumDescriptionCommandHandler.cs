using Application.Commands;
using Domain.Common;
using HousingReservation.Domain.Sanatoriums;
using MediatR;

namespace Application.Handlers
{
    internal class SaveSanatoriumDescriptionCommandHandler : IRequestHandler<SaveSanatoriumDescriptionCommand>
    {
        private readonly ISanatoriumRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public SaveSanatoriumDescriptionCommandHandler(ISanatoriumRepository sanatoriumRepository, IUnitOfWork unitOfWork)
        {
            _repository = sanatoriumRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(SaveSanatoriumDescriptionCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repository.GetByIdAsync(request.SanatoriumId);

            if (existing is null)
            {
                throw new InvalidOperationException("Санаторий не найден");
            }

            existing.Description = request.Description;

            _repository.Update(existing);
            await _unitOfWork.SaveAsync();
        }
    }
}
