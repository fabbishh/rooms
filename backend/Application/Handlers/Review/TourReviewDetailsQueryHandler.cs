using Application.Models;
using Application.Queries;
using Domain.Common;
using MediatR;

namespace Application.Handlers
{
    internal class TourReviewDetailsQueryHandler : IRequestHandler<TourReviewDetailsQuery, TourReviewDetailsModel>
    {
        private readonly ITourReviewRepository _repository;

        public TourReviewDetailsQueryHandler(ITourReviewRepository tourReviewRepository)
        {
            _repository = tourReviewRepository;
        }
        public async Task<TourReviewDetailsModel> Handle(TourReviewDetailsQuery request, CancellationToken cancellationToken)
        {
            var review = await _repository.GetByIdAsync(request.ReviewId);
            if (review == null)
            {
                return null;
            }

            var reviewDetails = new TourReviewDetailsModel
            {
                Id = review.Id,
                AuthorId = review.UserId,
                Comment = review.Content,
                OverallRating = review.OverallRating,
                Status = review.Status,
                TourId = review.TourId,
                TourName = review.Tour?.Name,
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
