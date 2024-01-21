using Application.Commands;
using Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    internal class UpdateTourReviewStatusCommandHandler : IRequestHandler<UpdateTourReviewStatus>
    {
        private readonly ILogger<UpdateTourReviewStatusCommandHandler> _logger;
        private readonly ITourReviewRepository _tourReviewRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateTourReviewStatusCommandHandler(
            ILogger<UpdateTourReviewStatusCommandHandler> logger,
            ITourReviewRepository tourReviewRepository,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _tourReviewRepository = tourReviewRepository;
            _unitOfWork = unitOfWork;

        }
        public async Task Handle(UpdateTourReviewStatus request, CancellationToken cancellationToken)
        {
            var existingReview = await _tourReviewRepository.GetByIdAsync(request.ReviewId);
            if (existingReview is null)
            {
                return;
            }

            existingReview.Status = request.Status;
            _tourReviewRepository.Update(existingReview);
            await _unitOfWork.SaveAsync();
            _logger.LogInformation("Статус отзыва {@id} тура {@tourId} был изменен на {@status}", existingReview.Id, existingReview.TourId, existingReview.Status.ToString());
        }
    }
}
