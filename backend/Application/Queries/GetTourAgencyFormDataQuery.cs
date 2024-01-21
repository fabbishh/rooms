using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class GetTourAgencyFormDataQuery : IRequest<TourAgencyProfileData>
    {
        public Guid TourAgencyId { get; set; }
    }
}
