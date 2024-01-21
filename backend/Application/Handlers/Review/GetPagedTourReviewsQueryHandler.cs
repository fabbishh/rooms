using Application.Extensions;
using Application.Models;
using Application.Queries;
using Domain.Common;
using Domain.Entities;
using Domain.Enums;
using HousingReservation.Domain.Models;
using MediatR;
using System.Linq.Expressions;

namespace Application.Handlers
{
    internal class GetPagedTourReviewsQueryHandler : IRequestHandler<GetPagedTourReviewsQuery, PagedResult<ReviewDto>>
    {
        private readonly ITourReviewRepository _repository;
        public GetPagedTourReviewsQueryHandler(ITourReviewRepository tourReviewRepository)
        {
            _repository = tourReviewRepository;
        }
        public async Task<PagedResult<ReviewDto>> Handle(GetPagedTourReviewsQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<TourReview, bool>>? filterExpression = null;

            if (request.TourId.HasValue)
            {
                Expression<Func<TourReview, bool>> tourFilter = r => r.TourId == request.TourId.Value;
                filterExpression = filterExpression == null
                    ? tourFilter
                    : filterExpression.And(tourFilter);

            }

            Expression<Func<TourReview, bool>> statusFilter = r => r.Status == AdminRequestStatus.Confirmed;
            filterExpression = filterExpression == null
                ? statusFilter
                : filterExpression.And(statusFilter);

            var pagedResult = await _repository.GetPagedAsync(request.PageNumber, request.PageSize, filterExpression);

            var reviews = pagedResult.Items.Select(i => new ReviewDto
            {
                Id = i.Id,
                OverallRating = i.OverallRating,
                Content = i.Content,
                UserName = $"{i.User?.FirstName} {i.User?.LastName}",
                Date = i.DateCreated
            }).ToList();

            var response = new PagedResult<ReviewDto>(reviews, pagedResult.TotalItems, pagedResult.PageNumber, pagedResult.PageSize);
            return response;
        }
    }
}
