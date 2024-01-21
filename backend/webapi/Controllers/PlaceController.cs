using Application.Commands;
using Application.Models;
using Application.Queries;
using HousingReservation.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using webapi.DTO;
using webapi.DTO.Places;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PlaceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Create([FromForm]SavePlaceDto request)
        {
            await _mediator.Send(new SavePlaceCommand
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                SubjectId = request.SubjectId,
                Photos = request.Photos,
                DeletedPhotos = request.DeletedPhotos,
            });

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlaceDto>> Get(Guid id)
        {
            var place = await _mediator.Send(new GetPlaceQuery { PlaceId = id });
            return Ok(place);
        }

        [HttpPost("GetPaged")]
        public async Task<ActionResult<PagedResult<PlaceDto>>> GetPaged([FromBody] PagedRequest<PlaceFilter> request)
        {
            var places = await _mediator.Send(new GetPagedPlacesQuery
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                SanatoriumId = request.Filter?.SanatoriumId,
                SearchQuery = request.Query
            });

            return Ok(places);
        }

        [HttpPost("UpdateSanatoriumPlaces")]
        public async Task<IActionResult> UpdateSanatoriumPlaces([FromBody] UpdateManySanatoriumPlacesDto request)
        {
            await _mediator.Send(new UpdateSanatoriumPlacesCommand
            {
                SanatoriumId = request.SanatoriumId,
                SanatoriumPlaces = request.SanatoriumPlaces.Select(p => new UpdateSanatoriumPlaceModel
                {
                    PlaceId = p.PlaceId,
                    SanatoriumPlaceId = p.SanatoriumPlaceId,
                }).ToList()
            });

            return Ok();
        }
    }
}
