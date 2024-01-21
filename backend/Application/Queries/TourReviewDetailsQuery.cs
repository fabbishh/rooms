using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class TourReviewDetailsQuery : IRequest<TourReviewDetailsModel>
    {
        public Guid ReviewId { get; set; }
    }
}
