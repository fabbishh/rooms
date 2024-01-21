using Application.Models;
using HousingReservation.Domain.Models;
using MediatR;

namespace Application.Queries
{
    public class GetPagedReviewsQuery : IRequest<PagedResult<ReviewDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Guid? SanatoriumId { get; set; }
    }
}
