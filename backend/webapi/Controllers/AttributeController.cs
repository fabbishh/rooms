using Application.Commands;
using Application.Models;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using webapi.DTO.Attributes;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AttributeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateSanatoriumComfort")]
        public async Task<IActionResult> Create(CreateAttributeDto request)
        {
            await _mediator.Send(new CreateAttributeCommand
            {
                Name = request.Name,
                AttributeGroupId = new Guid("22462aca-7ef2-11ee-b962-0242ac120002"),
                IsActive = request.IsActive,
                EntityType = 0
            });

            return Ok();
        }

        [HttpPost("CreateRoomComfort")]
        public async Task<IActionResult> CreateRoomComfort(CreateAttributeDto request)
        {
            await _mediator.Send(new CreateAttributeCommand
            {
                Name = request.Name,
                AttributeGroupId = new Guid("2d1674d2-7ef2-11ee-b962-0242ac120002"),
                IsActive = request.IsActive,
                EntityType = 1
            });

            return Ok();
        }

        [HttpPost("CreateService")]
        public async Task<IActionResult> CreateService(CreateAttributeDto request)
        {
            await _mediator.Send(new CreateAttributeCommand
            {
                Name = request.Name,
                AttributeGroupId = new Guid("f993d082-7ef1-11ee-b962-0242ac120002"),
                IsActive = request.IsActive,
                EntityType = 0
            });

            return Ok();
        }

        [HttpPost("create-sanatorium-food")]
        public async Task<IActionResult> CreateSanatoriumFood(CreateAttributeDto request)
        {
            await _mediator.Send(new CreateAttributeCommand
            {
                Name = request.Name,
                AttributeGroupId = new Guid("5c52815e-e12b-48fd-8429-b0cf4c3e995d"),
                IsActive = request.IsActive,
                EntityType = 0
            });

            return Ok();
        }

        [HttpPost("create-room-food")]
        public async Task<IActionResult> CreateRoomFood(CreateAttributeDto request)
        {
            await _mediator.Send(new CreateAttributeCommand
            {
                Name = request.Name,
                AttributeGroupId = new Guid("96de2246-871c-4a3d-b8e7-f179816dd483"),
                IsActive = request.IsActive,
                EntityType = 1
            });

            return Ok();
        }

        [HttpPost("create-room-bathroom")]
        public async Task<IActionResult> CreateRoomBathroom(CreateAttributeDto request)
        {
            await _mediator.Send(new CreateAttributeCommand
            {
                Name = request.Name,
                AttributeGroupId = new Guid("f2782387-51e8-4d8e-93f7-1d2ba96b09c8"),
                IsActive = request.IsActive,
                EntityType = 1
            });

            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteAttributesRequest request)
        {
            await _mediator.Send(new DeleteAttributesCommand
            {
                AttributeIds = request.AttributeIds,
            });

            return Ok();
        }

        [HttpPost("UpdateSanatoriumAttributes")]
        public async Task<IActionResult> UpdateSanatoriumAttributes(List<AddSanatoriumAttributeDto> request)
        {
            await _mediator.Send(new UpdateSanatoriumAttributesCommand
            {
                SanatoriumAttributes = request.Select(a => new CreateSanatoriumAttributeDto
                {
                    SanatoriumAttributeId = a.SanatoriumAttributeId,
                    IsActive = a.IsActive,
                }).ToList()
            });

            return Ok();
        }

        [HttpGet("comfort-attributes/{sanatoriumId}")]
        public async Task<IActionResult> GetSanatoriumComfortAttributes(Guid sanatoriumId)
        {
            var response = await _mediator.Send(new GetSanatoriumAttributesQuery
            {
                SanatoriumId = sanatoriumId,
                AttributeGroup = "SanatoriumComfort"
            });

            return Ok(response);
        }

        [HttpGet("service-attributes/{sanatoriumId}")]
        public async Task<ActionResult<List<SanatoriumAttributeDto>>> GetSanatoriumServiceAttributes(Guid sanatoriumId)
        {
            var response = await _mediator.Send(new GetSanatoriumAttributesQuery
            {
                SanatoriumId = sanatoriumId,
                AttributeGroup = "Service"
            });

            return Ok(response);
        }

        [HttpGet("sanatorium-food/{sanatoriumId}")]
        public async Task<ActionResult<List<SanatoriumAttributeDto>>> GetSanatoriumFoodAttributes(Guid sanatoriumId)
        {
            var response = await _mediator.Send(new GetSanatoriumAttributesQuery
            {
                SanatoriumId = sanatoriumId,
                AttributeGroup = "SanatoriumFood"
            });

            return Ok(response);
        }

        [HttpGet("room-food/{roomGroupId}")]
        public async Task<ActionResult<List<SanatoriumAttributeDto>>> GetRoomFoodAttributes(Guid roomGroupId)
        {
            var response = await _mediator.Send(new GetRoomAttributesQuery
            {
                RoomGroupId = roomGroupId,
                AttributeGroup = "RoomFood"
            });

            return Ok(response);
        }

        [HttpGet("room-comfort/{roomGroupId}")]
        public async Task<ActionResult<List<SanatoriumAttributeDto>>> GetRoomComfortAttributes(Guid roomGroupId)
        {
            var response = await _mediator.Send(new GetRoomAttributesQuery
            {
                RoomGroupId = roomGroupId,
                AttributeGroup = "RoomComfort"
            });

            return Ok(response);
        }

        [HttpGet("room-bathroom/{roomGroupId}")]
        public async Task<ActionResult<List<SanatoriumAttributeDto>>> GetRoomBathroomAttributes(Guid roomGroupId)
        {
            var response = await _mediator.Send(new GetRoomAttributesQuery
            {
                RoomGroupId = roomGroupId,
                AttributeGroup = "RoomBathroom"
            });

            return Ok(response);
        }

        [HttpGet("room-comfort")]
        public async Task<ActionResult<List<AttributeDto>>> GetComfortAttributesForRoom()
        {
            var response = await _mediator.Send(new GetAttributesQuery
            {
                AttributeGroup = "RoomComfort"
            });

            return Ok(response);
        }

        [HttpGet("sanatorium-comfort")]
        public async Task<ActionResult<List<AttributeDto>>> GetComfortAttributesForSanatorium()
        {
            var response = await _mediator.Send(new GetAttributesQuery
            {
                AttributeGroup = "SanatoriumComfort"
            });

            return Ok(response);
        }

        [HttpGet("sanatorium-service")]
        public async Task<ActionResult<List<AttributeDto>>> GetServiceAttributesForSanatorium()
        {
            var response = await _mediator.Send(new GetAttributesQuery
            {
                AttributeGroup = "Service"
            });

            return Ok(response);
        }

        [HttpGet("sanatorium-food")]
        public async Task<ActionResult<List<AttributeDto>>> GetFoodAttributesForSanatorium()
        {
            var response = await _mediator.Send(new GetAttributesQuery
            {
                AttributeGroup = "SanatoriumFood"
            });

            return Ok(response);
        }

        [HttpGet("room-food")]
        public async Task<ActionResult<List<AttributeDto>>> GetFoodAttributesForRoom()
        {
            var response = await _mediator.Send(new GetAttributesQuery
            {
                AttributeGroup = "RoomFood"
            });

            return Ok(response);
        }

        [HttpGet("room-bathroom")]
        public async Task<ActionResult<List<AttributeDto>>> GetBathroomAttributesForRoom()
        {
            var response = await _mediator.Send(new GetAttributesQuery
            {
                AttributeGroup = "RoomBathroom"
            });

            return Ok(response);
        }

    }
}
