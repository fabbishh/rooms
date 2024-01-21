using Application.Commands;
using Application.Models;
using Application.Queries;
using HousingReservation.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.DTO;
using webapi.DTO.Rooms;
using webapi.DTO.Sanatoriums;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        IMediator _mediator;
        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetPaged")]
        public async Task<ActionResult<PagedResult<RoomDto>>> GetPaged([FromBody] PagedRequest<RoomFilter> request)
        {
            var rooms = await _mediator.Send(new GetPagedRoomsQuery
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                Filter = new RoomFilterModel
                {
                    SanatoriumId = request.Filter?.SanatoriumId,
                    HousingType = request.Filter?.HousingType,
                    RoomGroupId = request.Filter?.RoomGroupId,
                }
            });

            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDetailsModel>> RoomDetails(Guid id)
        {
            var room = await _mediator.Send(new GetRoomDetailsQuery
            {
                RoomId = id
            });

            return Ok(room);
        }

        [HttpPost("GetRoomTableData")]
        public async Task<ActionResult<PagedResult<AdminRoomTable>>> GetRoomTableData([FromBody] RoomTableRequest request)
        {
            var rooms = await _mediator.Send(new GetRoomTableDataQuery
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                SanatoriumId = request.SanatoriumId,
                HousingType = request.HousingType
            });

            return Ok(rooms);
        }

        [Authorize]
        [HttpGet("get-form-data/{roomGroupId}")]
        public async Task<IActionResult> GetFormData(Guid roomGroupId)
        {
            var response = await _mediator.Send(new GetRoomFormDataQuery { RoomGroupId = roomGroupId });

            return Ok(response);
        }

        [Authorize]
        [HttpPost("CreateMany")]
        public async Task<IActionResult> CreateMany([FromForm] CreateRoomsDto request)
        {
            await _mediator.Send(new CreateRoomsCommand
            {
                PricePerNight = request.PricePerNight,
                BedroomCount = request.BedroomCount,
                SingleBedCount = request.SingleBedCount,
                DoubleBedCount = request.DoubleBedCount,
                Description = request.Description,
                RoomType = request.RoomType,
                HousingType = request.HousingType,
                SanatoriumId = request.SanatoriumId,
                Photos = request.Photos,
                MinDaysReservation = request.MinDaysReservation,
                Name = request.Name,
                Status = (Domain.Enums.AdminRequestStatus)request.Status,
                SameRoomCount = request.SameRoomCount,
                ComfortAttributes = request.ComfortAttributes.Select(ba => new RoomAttributeDto
                {
                    AttributeId = ba.AttributeId,
                    IsActive = ba.IsActive
                }).ToList(),
                FoodAttributes = request.FoodAttributes.Select(ba => new RoomAttributeDto
                {
                    AttributeId = ba.AttributeId,
                    RoomAttributeId = ba.RoomAttributeId,
                    IsActive = ba.IsActive
                }).ToList(),
                BathroomAttributes = request.BathroomAttributes.Select(ba => new RoomAttributeDto
                {
                    AttributeId = ba.AttributeId,
                    RoomAttributeId = ba.RoomAttributeId,
                    IsActive = ba.IsActive
                }).ToList(),
            });

            return Ok();
        }

        [Authorize]
        [HttpPost("UpdateMany")]
        public async Task<IActionResult> UpdateMany([FromForm] UpdateRoomsDto request)
        {
            await _mediator.Send(new UpdateRoomsCommand
            {
                Id = request.Id,
                PricePerNight = request.PricePerNight,
                BedroomCount = request.BedroomCount,
                SingleBedCount = request.SingleBedCount,
                DoubleBedCount = request.DoubleBedCount,
                Description = request.Description,
                RoomType = request.RoomType,
                SanatoriumId = request.SanatoriumId,
                NewPhotos = request.Photos,
                MinDaysReservation = request.MinDaysReservation,
                Name = request.Name,
                Status = (Domain.Enums.AdminRequestStatus)request.Status,
                SameRoomCount = request.SameRoomCount,
                DeletedPhotos = request.DeletedPhotos,
                ComfortAttributes = request.ComfortAttributes.Select(ba => new RoomAttributeDto
                {
                    AttributeId = ba.AttributeId,
                    RoomAttributeId = ba.RoomAttributeId,
                    IsActive = ba.IsActive
                }).ToList(),
                FoodAttributes = request.FoodAttributes.Select(ba => new RoomAttributeDto
                {
                    AttributeId = ba.AttributeId,
                    RoomAttributeId = ba.RoomAttributeId,
                    IsActive = ba.IsActive
                }).ToList(),
                BathroomAttributes = request.BathroomAttributes.Select(ba => new RoomAttributeDto
                {
                    AttributeId = ba.AttributeId,
                    RoomAttributeId = ba.RoomAttributeId,
                    IsActive = ba.IsActive
                }).ToList(),
            });

            return Ok();
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteRoomGroupsCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
