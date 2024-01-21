using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using webapi.DTO;
using webapi.DTO.Favourite;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FavouriteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddFavouriteRequest request)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            await _mediator.Send(new AddFavouriteSanatoriumCommand
            {
                UserId = new Guid(currentUserId!),
                SanatoriumId = request.SanatoriumId,
            });

            return Ok();
        }

        [Authorize]
        [HttpPost("Remove")]
        public async Task<IActionResult> Remove(RemoveFavouriteRequest request)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            await _mediator.Send(new RemoveFavouriteSanatoriumCommand
            {
                UserId = new Guid(currentUserId!),
                SanatoriumId = request.SanatoriumId,
            });

            return Ok();
        }

        [Authorize]
        [HttpPost("sanatoriums")]
        public async Task<IActionResult> GetFavouriteSanatoriums(PagedRequest<BaseFilter> request)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var response = await _mediator.Send(new FavouriteSanatoriumsQuery
            {
                UserId = new Guid(currentUserId!),
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            });

            return Ok(response);
        }
    }
}
