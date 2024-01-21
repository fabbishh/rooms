using Application.Commands;
using Application.Models;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.DTO.TourTypes;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TourTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<TourTypeModel>>> Get()
        {
            var tourTypes = await _mediator.Send(new GetTourTypesQuery { });
            return Ok(tourTypes);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTourTypeRequest request)
        {
            await _mediator.Send(new CreateTourTypeCommand { Name = request.Name });
            return Ok();
        }
    }
}
