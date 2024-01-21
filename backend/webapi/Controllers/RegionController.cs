using Application.Models;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using webapi.DTO.Region;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpPost]
        public async Task<IActionResult> SeedRegionsData()
        {
            await _regionService.SeedRegionDataAsync();

            return Ok();
        }

        [HttpPost("get-list")]
        public async Task<ActionResult<RegionModel>> GetList(RegionFilter request)
        {
            var regions = await _regionService.GetRegionsAsync(request.IsActive);

            return Ok(regions);
        }

        [HttpPost("update-activity")]
        public async Task<ActionResult<RegionModel>> UpdateActivity(UpdateActivityRequest request)
        {
            await _regionService.UpdateActivity(request.Id, request.IsActive);

            return Ok();
        }

        [HttpGet("get-default")]
        public async Task<ActionResult<RegionModel>> GetDefault()
        {
            var region = await _regionService.GetDefaultRegion();

            return Ok(region);
        }
    }
}
