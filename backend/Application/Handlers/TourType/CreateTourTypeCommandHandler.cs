using Application.Commands;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    internal class CreateTourTypeCommandHandler : IRequestHandler<CreateTourTypeCommand>
    {
        private readonly ITourTypeRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateTourTypeCommandHandler> _logger;
        public CreateTourTypeCommandHandler(ITourTypeRepository tourTypeRepository, IUnitOfWork unitOfWork, ILogger<CreateTourTypeCommandHandler> logger)
        {
            _repository = tourTypeRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task Handle(CreateTourTypeCommand request, CancellationToken cancellationToken)
        {
            var existingTourType = await _repository.FindAsync(tt => tt.Name == request.Name);
            if (existingTourType.Any())
            {
                throw new InvalidOperationException($"Tour type with name {request.Name} already exists");
            }

            var tourType = new TourType
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                IsActive = true,
                DateCreated = DateTime.UtcNow,
            };

            await _repository.AddAsync(tourType);
            await _unitOfWork.SaveAsync();
            _logger.LogInformation("Тип тура {@id} был добавлен", tourType.Id);
        }
    }
}
