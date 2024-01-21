using Application.Extensions;
using Application.Models;
using Application.Queries;
using AutoMapper;
using Domain.Common;
using Domain.Enums;
using HousingReservation.Domain.Entities;
using HousingReservation.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class GetPagedReviewsQueryHandler : IRequestHandler<GetPagedReviewsQuery, PagedResult<ReviewDto>>
    {
        private readonly IMapper _mapper;
        private readonly IReviewRepository _reviewRepository;

        public GetPagedReviewsQueryHandler(IMapper mapper, IReviewRepository reviewRepository)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
        }

        public async Task<PagedResult<ReviewDto>> Handle(GetPagedReviewsQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Review, bool>>? filterExpression = null;

            if (request.SanatoriumId.HasValue)
            {
                Expression<Func<Review, bool>> sanatoriumFilter = r => r.SanatoriumId == request.SanatoriumId.Value;
                filterExpression = filterExpression == null
                    ? sanatoriumFilter
                    : filterExpression.And(sanatoriumFilter);

            }

            Expression<Func<Review, bool>> statusFilter = r => r.Status == AdminRequestStatus.Confirmed;
            filterExpression = filterExpression == null
                ? statusFilter
                : filterExpression.And(statusFilter);

            var pagedResult = await _reviewRepository.GetPagedAsync(request.PageNumber, request.PageSize, filterExpression);

            var reviews = _mapper.Map<List<ReviewDto>>(pagedResult.Items);

            var response = new PagedResult<ReviewDto>(reviews, pagedResult.TotalItems, pagedResult.PageNumber, pagedResult.PageSize);
            return response;
        }
    }
}
