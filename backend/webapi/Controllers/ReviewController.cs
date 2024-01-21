using Application.Commands;
using Application.Models;
using Application.Queries;
using Domain.Enums;
using HousingReservation.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using webapi.DTO;
using webapi.DTO.Reviews;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetPaged")]
        public async Task<ActionResult<PagedResult<ReviewDto>>> GetPaged([FromBody] PagedRequest<ReviewFilter> request)
        {
            var reviews = await _mediator.Send(new GetPagedReviewsQuery
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                SanatoriumId = request.Filter?.SanatoriumId
            });

            return Ok(reviews);
        }

        [HttpPost("tour-reviews/GetPaged")]
        public async Task<ActionResult<PagedResult<ReviewDto>>> GetPagedTourReviews([FromBody] PagedRequest<ReviewFilter> request)
        {
            var reviews = await _mediator.Send(new GetPagedTourReviewsQuery
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TourId = request.Filter?.TourId
            });

            return Ok(reviews);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateReviewRequest request)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            await _mediator.Send(new CreateReviewCommand
            {
                CleanlinessRating = request.CleanlinessRating,
                Comment = request.Comment,
                EntertainmentRating = request.EntertainmentRating,
                FoodRating = request.FoodRating,
                LocationRating = request.LocationRating,
                OverallRating = request.OverallRating,
                StaffRating = request.StaffRating,
                TherapyRating = request.TherapyRating,
                UserId = new Guid(currentUserId!),
                SanatoriumId = request.SanatoriumId
            });

            return Ok();
        }

        [Authorize]
        [HttpPost("create-tour-review")]
        public async Task<IActionResult> CreateTourReview(CreateTourReviewREquest request)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            await _mediator.Send(new CreateTourReviewCommand
            {
                Comment = request.Comment,
                OverallRating = request.OverallRating,
                UserId = new Guid(currentUserId!),
                TourId = request.TourId
            });

            return Ok();
        }

        [Authorize]
        [HttpPost("sanatorium-reviews/GetTableData")]
        public async Task<IActionResult> GetSanatoriumReviewsTableData(PagedRequest<ReviewFilter> request)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var row = await _mediator.Send(new SanatoriumReviewsTableDataQuery
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                Status = request.Filter?.Status == null ? null : (AdminRequestStatus)request.Filter.Status
            });

            return Ok(row);
        }

        [Authorize]
        [HttpPost("tour-reviews/GetTableData")]
        public async Task<IActionResult> GetTourReviewsTableData(PagedRequest<ReviewFilter> request)
        {
            var rows = await _mediator.Send(new TourReviewsTableDataQuery
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                Status = request.Filter?.Status == null ? null : (AdminRequestStatus)request.Filter.Status
            });

            return Ok(rows);
        }

        [Authorize]
        [HttpPost("update-sanatorium-review-status")]
        public async Task<IActionResult> UpdateReviewStatus(UpdateSanatoriumReviewStatusRequest request)
        {
            await _mediator.Send(new UpdateSanatoriumReviewStatus { ReviewId = request.Id, Status = (AdminRequestStatus)request.Status });
            return Ok();
        }

        [Authorize]
        [HttpPost("update-tour-review-status")]
        public async Task<IActionResult> UpdateTourReviewStatus(UpdateSanatoriumReviewStatusRequest request)
        {
            await _mediator.Send(new UpdateTourReviewStatus { ReviewId = request.Id, Status = (AdminRequestStatus)request.Status });
            return Ok();
        }

        [Authorize]
        [HttpGet("modal-update-data/{reviewId}")]
        public async Task<IActionResult> SanatoriumReviewDetails(Guid reviewId)
        {
            var data = await _mediator.Send(new ReviewDetailsQuery { ReviewId = reviewId });
            return Ok(data);
        }

        [Authorize]
        [HttpGet("tour-review-details/{reviewId}")]
        public async Task<IActionResult> TourReviewDetails(Guid reviewId)
        {
            var data = await _mediator.Send(new TourReviewDetailsQuery { ReviewId = reviewId });
            return Ok(data);
        }
    }
}
