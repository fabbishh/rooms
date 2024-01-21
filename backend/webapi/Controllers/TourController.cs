using Application.Commands;
using Application.Models;
using Application.Queries;
using Domain.Enums;
using HousingReservation.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.DTO;
using webapi.DTO.Tours;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TourController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Save([FromForm] SaveTourRequest request)
        {
            await _mediator.Send(new SaveTourCommand
            {
                Id = request.Id,
                Name = request.Name,
                Days = request.Days,
                StartDates = request.StartDates.Select(d => new TourStartDate { Id = d.Id, StartDate = d.StartDate}).ToList(),
                IsActive = request.IsActive,
                Photos = request.Photos,
                DeletedPhotos = request.DeletedPhotos,
                PriceByGroup = (TourPriceType)request.PriceType == TourPriceType.ByGroup ? request.Price : null,
                PriceByTourist = (TourPriceType)request.PriceType == TourPriceType.ByTourist ? request.Price : null,
                TouristCountFrom = request.TouristCountFrom,
                TouristCountTo = request.TouristCountTo,
                Type = request.Type,
                TourAgencyId = request.TourAgencyId,
                Description = request.Description,
                Subject = request.Subject,
                Seasons = request.Seasons,
            });

            return Ok();
        }

        [Authorize]
        [HttpPost("save-by-admin")]
        public async Task<IActionResult> SaveByAdmin([FromForm]SaveTourByAdminRequest request)
        {
            await _mediator.Send(new SaveTourCommand
            {
                Id = request.Id,
                Name = request.Name,
                Days = request.Days,
                StartDates = request.StartDates.Select(d => new TourStartDate { Id = d.Id, StartDate = d.StartDate }).ToList(),
                IsActive = request.IsActive,
                Photos = request.Photos,
                DeletedPhotos = request.DeletedPhotos,
                PriceByGroup = (TourPriceType)request.PriceType == TourPriceType.ByGroup ? request.Price : null,
                PriceByTourist = (TourPriceType)request.PriceType == TourPriceType.ByTourist ? request.Price : null,
                TouristCountFrom = request.TouristCountFrom,
                TouristCountTo = request.TouristCountTo,
                Type = request.Type,
                TourAgencyId = request.TourAgencyId,
                Description = request.Description,
                Subject = request.Subject,
                Status = (AdminRequestStatus)request.Status,
                Seasons = request.Seasons,
            });

            return Ok();
        }

        [HttpPost("GetPaged")]
        public async Task<ActionResult<PagedResult<PagedToursItem>>> GetPaged(PagedRequest<TourFilter> request)
        {
            
            var response = await _mediator.Send(new GetPagedToursQuery 
            { 
                PageNumber = request.PageNumber, 
                PageSize = request.PageSize,
                Filter = new TourFilterModel
                {
                    DaysFrom = request.Filter?.DaysFrom,
                    DaysTo = request.Filter?.DaysTo,
                    StartDate = request.Filter?.StartDate,
                    EndDate = request.Filter?.EndDate,
                    PriceFrom = request.Filter?.PriceFrom,
                    PriceTo = request.Filter?.PriceTo,
                    Seasons = request.Filter?.Seasons,
                    TouristsFrom = request.Filter?.TouristsFrom,
                    TouristsTo = request.Filter?.TouristsTo,
                    TourType = request.Filter?.TourType,
                    SubjectId = request.Filter?.SubjectId,
                }
            });

            return Ok(response);
        }

        [Authorize]
        [HttpPost("GetTableData")]
        public async Task<ActionResult<PagedResult<ToursTableRow>>> GetTableData(PagedRequest<TourFilter> request)
        {

            var response = await _mediator.Send(new GetPagedToursTableDataQuery
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                Filter = new TourFilterModel
                {
                    TourAgencyId = request.Filter?.TourAgencyId,
                }
            });

            return Ok(response);
        }

        [Authorize]
        [HttpGet("get-form-data/{tourId}")]
        public async Task<ActionResult<TourFormData?>> GetFormData(Guid tourId)
        {
            var response = await _mediator.Send(new GetTourFormDataQuery { TourId = tourId });

            return Ok(response);
        }

        [HttpGet("{tourId}")]
        public async Task<ActionResult<TourFormData?>> GetTourDetails(Guid tourId)
        {
            var response = await _mediator.Send(new GetTourFormDataQuery { TourId = tourId });

            return Ok(response);
        }

        [HttpGet("get-dates/{tourId}")]
        public async Task<ActionResult<List<TourDateResponse>>> GetTourDates(Guid tourId)
        {
            var response = await _mediator.Send(new TourDatesQuery { TourId = tourId });

            return Ok(response);
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteToursCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
