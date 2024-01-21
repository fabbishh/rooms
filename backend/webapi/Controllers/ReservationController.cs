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
using webapi.DTO.Reservation;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost("CreateAuthorized")]
        public async Task<IActionResult> Create(CreateAuthorizedReservationRequest request)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            await _mediator.Send(new CreateAuthorizedReservationCommand
            {
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                RoomId = request.RoomId,
                AdultGuestsCount = request.AdultGuestsCount,
                ChildGuestsCount = request.ChildGuestsCount,
                GuestComment = request.GuestComment,
                UserId = new Guid(currentUserId!),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Patronymic = request.Patronymic,
                PhoneNumber = request.Phone,
            });

            return Ok();
        }

        [HttpPost("CreateUnauthorized")]
        public async Task<IActionResult> CreateUnauthorized(CreateUnathorizedREservationRequest request)
        {
            await _mediator.Send(new CreateUnathorizedReservationCommand
            {
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                RoomId = request.RoomId,
                AdultGuestsCount = request.AdultGuestsCount,
                ChildGuestsCount = request.ChildGuestsCount,
                GuestComment = request.GuestComment,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Patronymic = request.Patronymic,
                PhoneNumber = request.Phone,
            });

            return Ok();
        }

        [HttpGet("GetDisabledDatesForRoom/{roomId}")]
        public async Task<ActionResult<List<DateRangeModel>>> GetDisabledDatesForRoom(Guid roomId)
        {
            var response = await _mediator.Send(new DisabledDatesForRoomQuery { RoomId = roomId });

            return Ok(response);
        }

        [Authorize]
        [HttpPost("GetPaged")]
        public async Task<ActionResult<PagedResult<ReservationsTableRow>>> GetPagedReservations(PagedRequest<ReservationFilter> request )
        {
            var response = await _mediator.Send(new GetPagedReservationsQuery
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                Filter = new ReservationFilterModel
                {
                    SanatoriumId = request.Filter?.SanatoriumId,
                    Activity = request.Filter?.Activity,
                    Statuses = request.Filter?.Statuses,
                    UserId = request.Filter?.UserId,
                },
            });

            return Ok(response);
        }

        [Authorize]
        [HttpPost("user-reservations")]
        public async Task<ActionResult<PagedResult<ReservationsTableRow>>> GetUserReservations(PagedRequest<BaseFilter> request)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var response = await _mediator.Send(new GetPagedReservationsQuery
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                Filter = new ReservationFilterModel
                {
                    UserId = new Guid(currentUserId!),
                },
            });

            return Ok(response);
        }

        [Authorize]
        [HttpGet("{reservationId}")]
        public async Task<ActionResult<ReservationDetailsModel?>> Get(Guid reservationId)
        {
            var response = await _mediator.Send(new GetReservationQuery { ReservationId = reservationId });

            return Ok(response);
        }

        [Authorize]
        [HttpPut("UpdateStatus")]
        public async Task<ActionResult<ReservationDetailsModel?>> UpdateStatus(UpdateReservationStatusRequest request)
        {
            await _mediator.Send(new UpdateReservationStatusCommand { Id = request.Id, Status = (AdminRequestStatus)request.Status, Comment = request.Comment });

            return Ok();
        }


    }
}
