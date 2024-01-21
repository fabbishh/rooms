using Application.Models;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromoRowPlanController : ControllerBase
    {
        private readonly IMediator _mediiator;

        public PromoRowPlanController(IMediator mediator)
        {
            _mediiator = mediator;
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<PromoPlanModel>>> GetList()
        {
            var plans = await _mediiator.Send(new GetPromoRowPlansQuery());

            return Ok(plans);
        }
    }
}
