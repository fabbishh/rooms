using Application.Commands;
using Domain.Common;
using Domain.Entities;
using Domain.Enums;
using HousingReservation.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    internal class CreateTourReviewCommandHandler : IRequestHandler<CreateTourReviewCommand>
    {
        private readonly ITourReviewRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateTourReviewCommandHandler> _logger;
        public CreateTourReviewCommandHandler(
            ITourReviewRepository tourReviewRepository,
            IUnitOfWork unitOfWork,
            ILogger<CreateTourReviewCommandHandler> logger
            )
        {
            _repository = tourReviewRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task Handle(CreateTourReviewCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var review = new TourReview
            {
                Id = Guid.NewGuid(),
                DateCreated = DateTimeOffset.UtcNow,
                UserId = request.UserId,
                TourId = request.TourId,
                Content = request.Comment,
                OverallRating = request.OverallRating,
                Status = AdminRequestStatus.Pending,
                IsActive = false,
                Deleted = false,
            };

            await _repository.AddAsync(review);

            await _unitOfWork.SaveAsync();
            _logger.LogInformation("Отзыв {@id} был отправлен на модерацию", review.Id);
        }
    }
}
