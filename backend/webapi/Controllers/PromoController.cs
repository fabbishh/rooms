using Application.Commands;
using Application.Handlers.Promo;
using Application.Models;
using Application.Queries;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.DTO.Promo;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PromoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost("CreatePromoRowItem")]
        public async Task<IActionResult> CreatePromoRowItem(CreatePromoRowItem request)
        {
            await _mediator.Send(new CreatePromoRowItemCommand
            {
                SanatoriumId = request.SanatoriumId,
                PlanId = request.PlanId,
            });

            return Ok();
        }

        [HttpPost("GetPromoRowItems")]
        public async Task<ActionResult<List<PromoRowItemDto>>> GetPromoRowItems(GetPromoRowItemsRequest request)
        {
            var items = await _mediator.Send(new GetPromoRowItemsQuery { Region =  request.Region });
            return Ok(items);
        }

        [Authorize]
        [HttpPost("CreatePromoBlockItem")]
        public async Task<IActionResult> CreatePromoBlockItem(CreatePromoBlockItem request)
        {
            await _mediator.Send(new CreatePromoBlockItemCommand
            {
                SanatoriumId = request.SanatoriumId,
                TourId = request.TourId,
                TourAgencyId = request.TourAgencyId,
                RoomId = request.RoomId,
                PromoBlockId = request.PromoBlockId,
                Days = request.Days,
            });

            return Ok();
        }

        [HttpGet("block-one-items")]
        public async Task<ActionResult<List<PromoBlockItemModel>>> GetPromoBlockOneItems()
        {
            var items = await _mediator.Send(new PromoBlockItemsQuery { PromoBlockId = new Guid("71bb6a81-b4d1-4cce-8d62-8a2082667faa") });
            return Ok(items);
        }

        [HttpGet("block-two-items")]
        public async Task<ActionResult<List<PromoBlockItemModel>>> GetPromoBlockTwoItems()
        {
            var items = await _mediator.Send(new PromoBlockItemsQuery { PromoBlockId = new Guid("03edae16-f426-4a37-8a83-081a44c3e17a") });
            return Ok(items);
        }

        [HttpGet("block-three-items")]
        public async Task<ActionResult<List<PromoBlockItemModel>>> GetPromoBlockThreeItems()
        {
            var items = await _mediator.Send(new PromoBlockItemsQuery { PromoBlockId = new Guid("c9bc5230-a03c-4aee-980a-3995abe2dbe3") });
            return Ok(items);
        }

        [Authorize]
        [HttpGet("promo-blocks-prices")]
        public async Task<IActionResult> GetPromoBlocks()
        {
            var blocks = await _mediator.Send(new GetPromoBlocksPricesQuery());

            return Ok(blocks);
        }

        [Authorize]
        [HttpGet("row-info/{sanatoriumId}")]
        public async Task<IActionResult> PromoRowInfo(Guid sanatoriumId)
        {
            var info = await _mediator.Send(new GetPromoRowInfoQuery { SanatoriumId = sanatoriumId});

            return Ok(info);
        }

        [Authorize]
        [HttpPost("blocks-info")]
        public async Task<IActionResult> PromoBlocksInfo(GetPromoBlocksInfoRequest request)
        {
            var info = await _mediator.Send(new GetPromoBlocksInfoQuery 
            { 
                SanatoriumId = request.SanatoriumId,
                TourAgencyId = request.TourAgencyId,
                TourId = request.TourId,
                RoomId = request.RoomId,
            });

            return Ok(info);
        }

        [Authorize]
        [HttpPost("requests")]
        public async Task<IActionResult> GetPromoRequests(GetPromoRequests request)
        {
            var info = await _mediator.Send(new GetPromoRequestsQuery 
            { 
                SanatoriumId = request.SanatoriumId,
                RoomId = request.RoomId,
                TourAgencyId = request.TourAgencyId,
                TourId = request.TourId,
            });

            return Ok(info);
        }

        [Authorize]
        [HttpPost("change-status")]
        public async Task<IActionResult> ChangeRequestStatus(ChangePromoStatusRequest request)
        {
            await _mediator.Send(new ChangePromoStatusCommand { PromoId = request.PromoId, Status = (AdminRequestStatus)request.Status, PromoType = (PromoType)request.PromoType});

            return Ok();
        }
    }
}
