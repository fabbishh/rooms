using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class TourDatesQuery : IRequest<List<TourDateResponse>>
    {
        public Guid TourId { get; set; } 
    }
}
