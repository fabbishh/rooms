using Application.Commands;
using Application.Services;
using AutoMapper;
using Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Security.Principal;

namespace Application.Handlers
{
    public class CreateAttributeCommandHandler : IRequestHandler<CreateAttributeCommand>
    {
        private readonly IAttributeRepository _attributeRepository;
        private readonly IAttributeService _attributeService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateAttributeCommandHandler> _logger;
        public CreateAttributeCommandHandler(
            IAttributeRepository attributeRepository,
            IAttributeService attributeService,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<CreateAttributeCommandHandler> logger)
        {
            _attributeRepository = attributeRepository;
            _attributeService = attributeService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Handle(CreateAttributeCommand request, CancellationToken cancellationToken)
        {
            var attribute = _mapper.Map<HousingReservation.Domain.Entities.Attribute>(request);

            await _attributeRepository.AddAsync(attribute);
            await _unitOfWork.SaveAsync();
            if(attribute.IsActive)
            {
                if (request.EntityType == 0)
                {
                    await _attributeService.AddAttributeToSanatoriums(attribute);
                }
                else if (request.EntityType == 1)
                {
                    await _attributeService.AddAttributeToRoomGroups(attribute);
                }
            }
            _logger.LogInformation("Создан атрибут {@attribute}", attribute);
        }
    }
}
