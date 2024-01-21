using Application.Models;
using Application.Queries;
using HousingReservation.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MealTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<MealTypeDto>>> Get()
        {
            var response = await _mediator.Send(new GetMealTypeQuery { });

            return Ok(response);
        }
    }
}
