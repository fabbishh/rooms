using Application.Commands;
using Application.Models;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using webapi.DTO.SanatoriumTypes;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanatoriumTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SanatoriumTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-list")]
        public async Task<ActionResult<List<SanatoriumTypeModel>>> GetList()
        {
            var types = await _mediator.Send(new SanatoriumTypeQuery { });

            return Ok(types);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSanatoriumTypeRequest request)
        {
            await _mediator.Send(new CreateSanatoriumTypeCommand { Name = request.Name });

            return Ok();
        }
    }
}
