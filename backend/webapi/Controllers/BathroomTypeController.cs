using Application.Models;
using Application.Queries;
using HousingReservation.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BathroomTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BathroomTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<BathroomTypeDto>>> Get()
        {
            var response = await _mediator.Send(new GetBathroomTypeQuery { });

            return Ok(response);
        }
    }
}
