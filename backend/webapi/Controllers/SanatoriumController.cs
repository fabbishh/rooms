using Application.Commands;
using Application.Models;
using Application.Queries;
using Domain.Enums;
using HousingReservation.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using webapi.DTO;
using webapi.DTO.Sanatoriums;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanatoriumController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SanatoriumController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost("Save")]
        public async Task<ActionResult<Guid>> Save([FromForm]SaveSanatoriumDto request)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var sanatoriumId = await _mediator.Send(new SaveSanatoriumCommand
            {
                Id = request.Id,
                Name = request.Name,
                Email = request.Email,
                ObjectType = request.ObjectType,
                CheckInTime = request.CheckInTime,
                CheckOutTime = request.CheckOutTime,
                Season = (SanatoriumSeason)request.Season,
                Status = AdminRequestStatus.Pending,
                Location = request.Location,
                OwnerId = new Guid(currentUserId!),
                Photo = request.Photo,
                SubjectId = request.SubjectId,
            });

            return Ok(sanatoriumId);
        }

        [Authorize]
        [HttpPost("save-description")]
        public async Task<IActionResult> SaveDescription(SaveSanatoriumDescriptionRequest request)
        {
            await _mediator.Send(new SaveSanatoriumDescriptionCommand
            {
                SanatoriumId = request.SanatoriumId,
                Description = request.Description,
            });

            return Ok();
        }

        [Authorize]
        [HttpGet("description/{sanatoriumId}")]
        public async Task<IActionResult> GetDescription(Guid sanatoriumId)
        {
            var description = await _mediator.Send(new GetSanatoriumDescriptionQuery
            {
                SanatoriumId = sanatoriumId,
            });

            return Ok(description);
        }

        [Authorize]
        [HttpPost("Save-By-Admin")]
        public async Task<ActionResult<Guid>> SaveByAdmin([FromForm] SaveSanatoriumByAdminRequest request)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var sanatoriumId = await _mediator.Send(new SaveSanatoriumCommand
            {
                Id = request.Id,
                Name = request.Name,
                Email = request.Email,
                ObjectType = request.ObjectType,
                CheckInTime = request.CheckInTime,
                CheckOutTime = request.CheckOutTime,
                Season = (SanatoriumSeason)request.Season,
                Status = (AdminRequestStatus)request.Status,
                Location = request.Location,
                OwnerId = request.OwnerId,
                Photo = request.Photo,
                SubjectId = request.SubjectId,
            });

            return Ok(sanatoriumId);
        }

        [HttpPost("GetPaged")]
        public async Task<ActionResult<PagedResult<SanatoriumDto>>> GetPaged([FromBody] PagedRequest<SanatoriumFilter> request)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var pagedSanatoriums = await _mediator.Send(new GetPagedSanatoriumsQuery
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                ComfortAttributeIds = request.Filter?.ComfortAttributeIds,
                ServiceAttributeIds = request.Filter?.ServiceAttributeIds,
                FoodAttributeIds = request.Filter?.FoodAttributeIds,
                BathAttributeIds = request.Filter?.BathAttributeIds,
                BedroomCounts = request.Filter?.BedroomCounts,
                HousingTypes = request.Filter?.HousingTypes,
                PriceFrom = request.Filter?.PriceFrom,
                PriceTo = request.Filter?.PriceTo,
                Seasons = request.Filter?.Seasons,
                RegionId = request.Filter?.RegionId,
                UserId = currentUserId is null ? null : new Guid(currentUserId),  
            });

            return Ok(pagedSanatoriums);
        }

        [HttpGet("list")]
        public async Task<ActionResult<PagedResult<SanatoriumDto>>> GetAll()
        {
            var pagedSanatoriums = await _mediator.Send(new GetSanatoriumsQuery());

            return Ok(pagedSanatoriums);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SanatoriumDetailsDto>> Get(Guid id)
        {
            var sanatorium = await _mediator.Send(new GetSanatoriumQuery
            {
                Id = id
            });

            return Ok(sanatorium);
        }

        [HttpGet("GetSanatoriumProfileData/{sanatoriumId}")]
        public async Task<ActionResult<SanatoriumDetailsDto>> GetSanatoriumProfileData(Guid sanatoriumId)
        {
            var sanatorium = await _mediator.Send(new GetSanatoriumProfileDataQuery
            {
                SanatoriumId = sanatoriumId
            });

            return Ok(sanatorium);
        }


        [Authorize]
        [HttpPost("GetTableData")]
        public async Task<ActionResult<PagedResult<SanatoriumTableRow>>> GetTableData(PagedRequest<SanatoriumFilter> request)
        {
            var data = await _mediator.Send(new GetSanatoriumsTableDataQuery { PageNumber = request.PageNumber, PageSize = request.PageSize });
            return Ok(data);
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteSanatoriumsRequest request)
        {
            await _mediator.Send(new DeleteSanatoriumsCommand { Ids = request.Ids });
            return Ok();
        }

        [HttpGet("get-by-user/{userId}")]
        public async Task<ActionResult<SanatoriumProfileDataDto>> GetByUserId(Guid userId)
        {
            var sanatorium = await _mediator.Send(new GetSanatoriumByUserQuery
            {
                UserId = userId
            });

            return Ok(sanatorium);
        }
    }
}
