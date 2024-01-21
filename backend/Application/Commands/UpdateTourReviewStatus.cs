using Domain.Enums;
using MediatR;

namespace Application.Commands
{
    public class UpdateTourReviewStatus : IRequest
    {
        public Guid ReviewId { get; set; }
        public AdminRequestStatus Status { get; set; }
    }
}
