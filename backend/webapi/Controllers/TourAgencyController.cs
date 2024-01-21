using Application.Commands;
using Application.Models;
using Application.Queries;
using HousingReservation.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using webapi.DTO;
using webapi.DTO.TourAgency;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourAgencyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TourAgencyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost("save-profile")]
        public async Task<IActionResult> Save([FromForm] SaveTourAgencyDto request)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            await _mediator.Send(new SaveTourAgencyCommand
            {
                Id = request.Id,
                Name = request.Name,
                OwnerId = new Guid(currentUserId!),
                Location = request.Location,
                Link = request.Link,
                Email = request.Email,
                Description = request.Description,
                Logo = request.Logo,
                Status = Domain.Enums.AdminRequestStatus.Pending,
                SubjectId = request.SubjectId,
            });

            return Ok();
        }

        [Authorize]
        [HttpPost("save-by-admin")]
        public async Task<IActionResult> SaveByAdmin([FromForm] SaveAgencyByAdminDto request)
        {
            await _mediator.Send(new SaveTourAgencyCommand
            {
                Id = request.Id,
                Name = request.Name,
                OwnerId = request.OwnerId,
                Location = request.Location,
                Link = request.Link,
                Email = request.Email,
                Description = request.Description,
                Logo = request.Logo,
                Status = (Domain.Enums.AdminRequestStatus)request.Status,
                SubjectId = request.SubjectId,
            });

            return Ok();
        }

        [Authorize]
        [HttpGet("profile")]
        public async Task<ActionResult<TourAgencyProfileData>> GetProfileData()
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var response = await _mediator.Send(new GetTourAgencyProfileDataQuery { UserId = new Guid(currentUserId!) });

            return Ok(response);
        }

        [Authorize]
        [HttpGet("form-data/{tourAgencyId}")]
        public async Task<ActionResult<TourAgencyProfileData>> GetFormData(Guid tourAgencyId)
        {
            var response = await _mediator.Send(new GetTourAgencyFormDataQuery { TourAgencyId = tourAgencyId });

            return Ok(response);
        }

        [Authorize]
        [HttpPost("GetTableData")]
        public async Task<ActionResult<PagedResult<TourAgencyTableRow>>> GetTableData(PagedRequest<BaseFilter> request)
        {
            var data = await _mediator.Send(new GetTourAgenciesTableDataQuery { PageNumber = request.PageNumber, PageSize = request.PageSize, });

            return Ok(data);
        }

        [Authorize]
        [HttpGet("get-by-user/{userId}")]
        public async Task<ActionResult<PagedResult<TourAgencyTableRow>>> GetByUser(Guid userId)
        {
            var response = await _mediator.Send(new GetTourAgencyProfileDataQuery { UserId = userId });

            return Ok(response);
        }

        [Authorize]
        [HttpGet("list")]
        public async Task<ActionResult<List<TourAgencyListItem>>> List()
        {
            var response = await _mediator.Send(new TourAgencyListQuery());

            return Ok(response);
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteTourAgencyCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }

    }
}
