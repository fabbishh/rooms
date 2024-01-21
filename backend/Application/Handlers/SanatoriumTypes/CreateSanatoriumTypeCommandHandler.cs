using Application.Commands;
using Application.Exceptions;
using Domain.Common;
using Domain.Entities;
using HousingReservation.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.SanatoriumTypes
{
    internal class CreateSanatoriumTypeCommandHandler : IRequestHandler<CreateSanatoriumTypeCommand>
    {
        private readonly ISanatoriumTypeRepository _sanatoriumTypeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateSanatoriumTypeCommandHandler> _logger;
        public CreateSanatoriumTypeCommandHandler(
            IUnitOfWork unitOfWork, 
            ISanatoriumTypeRepository sanatoriumTypeRepository,
            ILogger<CreateSanatoriumTypeCommandHandler> logger
            )
        {
            _sanatoriumTypeRepository = sanatoriumTypeRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }


        public async Task Handle(CreateSanatoriumTypeCommand request, CancellationToken cancellationToken)
        {
            var existingType = await _sanatoriumTypeRepository.FindAsync(t => t.Name == request.Name);

            if (existingType.Any()) { throw new SanatoriumTypeExistsException(request.Name); }

            var mappedType = new SanatoriumType
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                IsActive = true,
                DateCreated = DateTimeOffset.UtcNow,
            };

            await _sanatoriumTypeRepository.AddAsync(mappedType);
            await _unitOfWork.SaveAsync();
            _logger.LogInformation("Тип санатория {@id} был создан", mappedType.Id);
        }
    }
}
