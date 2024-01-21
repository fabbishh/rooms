using System.Net;

namespace webapi.DTO.Places
{
    public class UpdateManySanatoriumPlacesDto
    {
        public Guid SanatoriumId { get; set; }
        public List<UpdateSanatoriumPlaceDto> SanatoriumPlaces { get; set; }
    }
}
