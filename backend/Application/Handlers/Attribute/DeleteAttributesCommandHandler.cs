using Application.Commands;
using Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers
{
    internal class DeleteAttributesCommandHandler : IRequestHandler<DeleteAttributesCommand>
    {
        private readonly IAttributeRepository _attributeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteAttributesCommandHandler> _logger;
        public DeleteAttributesCommandHandler(IAttributeRepository attributeRepository, IUnitOfWork unitOfWork, ILogger<DeleteAttributesCommandHandler> logger)
        {
            _attributeRepository = attributeRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task Handle(DeleteAttributesCommand request, CancellationToken cancellationToken)
        {
            if(!request.AttributeIds.Any())
            {
                return;
            }

            var attributes = await _attributeRepository.FindAsync(a => request.AttributeIds.Contains(a.Id));

            foreach(var attribute in attributes)
            {
                _attributeRepository.SetDeletedFlag(attribute);
            }

            await _unitOfWork.SaveAsync();
            _logger.LogInformation("Удалены атрибуты {@ids}", request.AttributeIds);

        }
    }
}
