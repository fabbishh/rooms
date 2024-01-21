using Application.Extensions;
using Application.Models;
using Application.Queries;
using Domain.Common;
using HousingReservation.Domain.Entities;
using HousingReservation.Domain.Models;
using MediatR;
using System.Linq.Expressions;

namespace Application.Handlers
{
    internal class SanatoriumReviewsTableDataQueryHandler : IRequestHandler<SanatoriumReviewsTableDataQuery, PagedResult<SanatoriumReviewTableRow>?>
    {
        private readonly IReviewRepository _reviewRepository;
        public SanatoriumReviewsTableDataQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task<PagedResult<SanatoriumReviewTableRow>?> Handle(SanatoriumReviewsTableDataQuery request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                return null;
            }

            Expression<Func<Review, bool>>? filterExpression = null;

            if (request.Status is not null)
            {
                Expression<Func<Review, bool>> statusFilter = s => s.Status == request.Status;
                filterExpression = filterExpression == null
                    ? statusFilter
                    : filterExpression.And(statusFilter);
            }

            var pagedResult = await _reviewRepository.GetPagedAsync(request.PageNumber, request.PageSize, filterExpression);

            var mappedItems = pagedResult.Items.Select(x => new SanatoriumReviewTableRow
            {
                Id = x.Id,
                DateCreated = x.DateCreated,
                SanatoriumId = x.SanatoriumId,
                SanatoriumName = x.Sanatorium.Name,
                Status = x.Status,
                UserId = x.UserId,
                UserName = x.User?.Email,
                Rating = x.OverallRating
            }).OrderByDescending(x => x.DateCreated).ToList();

            return new PagedResult<SanatoriumReviewTableRow>(mappedItems, pagedResult.TotalItems, pagedResult.PageNumber, pagedResult.PageSize);
        }
    }
}
