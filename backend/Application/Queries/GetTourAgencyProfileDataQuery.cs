using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class GetTourAgencyProfileDataQuery : IRequest<TourAgencyProfileData>
    {
        public Guid UserId { get; set; }
    }
}
