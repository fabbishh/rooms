using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class GetTourFormDataQuery : IRequest<TourFormData?>
    {
        public Guid TourId { get; set; }
    }
}
