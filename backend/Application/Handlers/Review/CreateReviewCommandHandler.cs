using Application.Commands;
using Domain.Common;
using Domain.Enums;
using HousingReservation.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers
{
    internal class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateReviewCommandHandler> _logger;
        public CreateReviewCommandHandler(
            IUnitOfWork unitOfWork, 
            IReviewRepository reviewRepository,
            ILogger<CreateReviewCommandHandler> logger)
        {

            _unitOfWork = unitOfWork;
            _reviewRepository = reviewRepository;
            _logger = logger;
        }

        public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var review = new Review
            {
                Id = Guid.NewGuid(),
                DateCreated = DateTimeOffset.UtcNow,
                UserId = request.UserId,
                Content = request.Comment,
                CleanlinessRating = request.CleanlinessRating,
                EntertainmentRating = request.EntertainmentRating,
                FoodRating = request.FoodRating,
                LocationRating = request.LocationRating,
                OverallRating = request.OverallRating,
                StaffRating = request.StaffRating,
                TherapyRating = request.TherapyRating,
                SanatoriumId = request.SanatoriumId,
                Status = AdminRequestStatus.Pending,
                IsActive = false,
                Deleted = false,
            };

            await _reviewRepository.AddAsync(review);

            await _unitOfWork.SaveAsync();
            _logger.LogInformation("Отзыв {@id} был отправлен на модерацию", review.Id);
        }
    }
}
