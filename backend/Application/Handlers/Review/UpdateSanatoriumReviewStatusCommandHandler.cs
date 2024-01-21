using Application.Commands;
using Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers
{
    internal class UpdateSanatoriumReviewStatusCommandHandler : IRequestHandler<UpdateSanatoriumReviewStatus>
    {
        private readonly ILogger<UpdateSanatoriumReviewStatusCommandHandler> _logger;
        private readonly IReviewRepository _reviewRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateSanatoriumReviewStatusCommandHandler(
            IUnitOfWork unitOfWork,
            IReviewRepository reviewRepository,
            ILogger<UpdateSanatoriumReviewStatusCommandHandler> logger
            )
        {

            _unitOfWork = unitOfWork;
            _logger = logger;
            _reviewRepository = reviewRepository;
        }
        public async Task Handle(UpdateSanatoriumReviewStatus request, CancellationToken cancellationToken)
        {
            var existingReview = await _reviewRepository.GetByIdAsync(request.ReviewId);
            if (existingReview is null)
            {
                return;
            }

            existingReview.Status = request.Status;
            _reviewRepository.Update(existingReview);
            await _unitOfWork.SaveAsync();
            _logger.LogInformation("Статус отзыва {@id} санатория {@sanatoriumId} был изменен на {@status}", existingReview.Id, existingReview.SanatoriumId, existingReview.Status.ToString());
        }
    }
}
