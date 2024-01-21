using Application.Models;
using Domain.Enums;
using HousingReservation.Domain.Models;
using MediatR;

namespace Application.Queries
{
    public class TourReviewsTableDataQuery : IRequest<PagedResult<TourReviewsRow>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public AdminRequestStatus? Status { get; set; }
    }
}
