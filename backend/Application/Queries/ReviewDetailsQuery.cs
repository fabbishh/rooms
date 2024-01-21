using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class ReviewDetailsQuery : IRequest<ReviewDetailsModel>
    {
        public Guid ReviewId { get; set; }
    }
}
