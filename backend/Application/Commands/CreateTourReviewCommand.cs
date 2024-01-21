using MediatR;

namespace Application.Commands
{
    public class CreateTourReviewCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid TourId { get; init; }
        public string Comment { get; init; }
        public int OverallRating { get; init; }
    }
}
