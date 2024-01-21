using Application.Models;
using Application.Queries;
using Domain.Common;
using MediatR;

namespace Application.Handlers
{
    internal class ReviewDetailsQueryHandler : IRequestHandler<ReviewDetailsQuery, ReviewDetailsModel>
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewDetailsQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task<ReviewDetailsModel> Handle(ReviewDetailsQuery request, CancellationToken cancellationToken)
        {
            var review = await _reviewRepository.GetByIdAsync(request.ReviewId);
            if(review == null)
            {
                return null;
            }

            var reviewDetails = new ReviewDetailsModel
            {
                Id = review.Id,
                AuthorId = review.UserId,
                CleanlinessRating = review.CleanlinessRating,
                Comment = review.Content,
                EntertainmentRating = review.EntertainmentRating,
                FoodRating = review.FoodRating,
                LocationRating = review.LocationRating,
                OverallRating = review.OverallRating,
                SanatoriumId = review.SanatoriumId,
                SanatoriumName = review.Sanatorium?.Name,
                StaffRating = review.StaffRating,
                Status = review.Status,
                TherapyRating = review.TherapyRating,
                Author = new AuthorModel
                {
                    Email = review.User?.Email,
                    PhoneNumber = review.User?.PhoneNumber,
                    FirstName = review.User?.FirstName,
                    LastName = review.User?.LastName,
                    Patronymic = review.User?.Patronymic,
                },
            };

            return reviewDetails;
        }
    }
}
