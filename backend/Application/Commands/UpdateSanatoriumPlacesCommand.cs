using Application.Models;
using MediatR;

namespace Application.Commands
{
    public class UpdateSanatoriumPlacesCommand : IRequest
    {
        public Guid SanatoriumId { get; set; }
        public List<UpdateSanatoriumPlaceModel> SanatoriumPlaces { get; set; }
    }
}
