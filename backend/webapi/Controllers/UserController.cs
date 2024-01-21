using Application.Commands;
using Application.Models;
using Application.Queries;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using webapi.DTO.Users;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("sanatorium-admins")]
        public async Task<ActionResult<List<UserModel>>> GetSanatoriumAdminsList()
        {
            var users = await _mediator.Send(new GetUserListQuery { Role = Domain.Enums.Role.SanatoriumAdmin});
            return Ok(users);
        }

        [Authorize]
        [HttpGet("tourAgency-admins")]
        public async Task<ActionResult<List<UserModel>>> GetTourAgencyAdminsList()
        {
            var users = await _mediator.Send(new GetUserListQuery { Role = Domain.Enums.Role.TourAgencyAdmin });
            return Ok(users);
        }

        [Authorize]
        [HttpGet("list")]
        public async Task<ActionResult<List<UserModel>>> GetList()
        {
            var users = await _mediator.Send(new GetUserListQuery());
            return Ok(users);
        }

        [Authorize]
        [HttpGet("profile")]
        public async Task<ActionResult<UserModel>> GetUserProfile()
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var user = await _mediator.Send(new GetUserProfileQuery { UserId = new Guid(currentUserId!)});

            return Ok(user);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUser(Guid id)
        {
            var user = await _mediator.Send(new GetUserProfileQuery { UserId = id });

            return Ok(user);
        }

        [Authorize]
        [HttpPost("save-profile")]
        public async Task<ActionResult<UserModel>> SaveUserProfile(SaveUserRequest request)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            await _mediator.Send(new SaveUserCommand
            {
                Id = new Guid(currentUserId!),
                Birthday = request.Birthday,
                FirstName = request.FirstName,
                LastName = request.LastName, 
                Gender = request.Gender, 
                Patronymic = request.Patronymic, 
                Phone = request.Phone,
                Role = Role.User
            });

            return Ok();
        }

        [Authorize]
        [HttpPost("save-by-admin")]
        public async Task<ActionResult<UserModel>> SaveByAdmin(SaveUserByAdminRequest request)
        {
            await _mediator.Send(new SaveUserCommand
            {
                Id = request.Id,
                Birthday = request.Birthday,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = request.Gender,
                Patronymic = request.Patronymic,
                Phone = request.Phone,
                Role = (Role)request.Role,
                Email = request.Email
            });

            return Ok();
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteUsersCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
