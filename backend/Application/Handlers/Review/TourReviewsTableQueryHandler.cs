using Application.Extensions;
using Application.Models;
using Application.Queries;
using Domain.Common;
using Domain.Entities;
using HousingReservation.Domain.Entities;
using HousingReservation.Domain.Models;
using MediatR;
using System.Linq.Expressions;

namespace Application.Handlers
{
    internal class TourReviewsTableQueryHandler : IRequestHandler<TourReviewsTableDataQuery, PagedResult<TourReviewsRow>>
    {
        private readonly ITourReviewRepository _tourReviewRepository;
        public TourReviewsTableQueryHandler(ITourReviewRepository tourReviewRepository)
        {
            _tourReviewRepository = tourReviewRepository;
        }

        public async Task<PagedResult<TourReviewsRow>> Handle(TourReviewsTableDataQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return null;
            }

            Expression<Func<TourReview, bool>>? filterExpression = null;

            if (request.Status is not null)
            {
                Expression<Func<TourReview, bool>> statusFilter = s => s.Status == request.Status;
                filterExpression = filterExpression == null
                    ? statusFilter
                    : filterExpression.And(statusFilter);
            }

            var pagedResult = await _tourReviewRepository.GetPagedAsync(request.PageNumber, request.PageSize, filterExpression);

            var mappedItems = pagedResult.Items.Select(x => new TourReviewsRow
            {
                Id = x.Id,
                DateCreated = x.DateCreated,
                TourId = x.Id,
                TourName = x.Tour?.Name,
                Status = x.Status,
                UserId = x.UserId,
                UserName = x.User?.Email,
                Rating = x.OverallRating
            }).OrderByDescending(x => x.DateCreated).ToList();

            return new PagedResult<TourReviewsRow>(mappedItems, pagedResult.TotalItems, pagedResult.PageNumber, pagedResult.PageSize);
        }
    }
}
