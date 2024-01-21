using Application.Models;
using HousingReservation.Domain.Models;
using MediatR;

namespace Application.Queries
{
    public class GetPagedTourReviewsQuery : IRequest<PagedResult<ReviewDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Guid? TourId { get; set; }
    }
}
