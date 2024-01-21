using Application.Commands;
using Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers
{
    public class UpdateSanatoriumAttributeCommandHandler : IRequestHandler<UpdateSanatoriumAttributesCommand>
    {
        private readonly ISanatoriumAttributeRepository _sanatoriumAttributeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateSanatoriumAttributeCommandHandler> _logger;
        public UpdateSanatoriumAttributeCommandHandler(
            ISanatoriumAttributeRepository sanatoriumAttributeRepository,
            IUnitOfWork unitOfWork,
            ILogger<UpdateSanatoriumAttributeCommandHandler> logger
            )
        {
            _sanatoriumAttributeRepository = sanatoriumAttributeRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task Handle(UpdateSanatoriumAttributesCommand request, CancellationToken cancellationToken)
        {
            Guid? sanatoriumId = null;
            foreach (var updateAttribute in request.SanatoriumAttributes)
            {
                var existingAttribute = await _sanatoriumAttributeRepository.GetByIdAsync(updateAttribute.SanatoriumAttributeId);
                if (existingAttribute != null)
                {
                    existingAttribute.IsActive = updateAttribute.IsActive;
                    _sanatoriumAttributeRepository.Update(existingAttribute);
                    sanatoriumId = existingAttribute.SanatoriumId;
                }
            }

            await _unitOfWork.SaveAsync();
            _logger.LogInformation("Атрибуты санатория {@id} обновлены", sanatoriumId);
        }
    }
}
