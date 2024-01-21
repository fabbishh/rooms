using Application.Models;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoManager _photoManager;
        public PhotoController(IPhotoManager photoManager)
        {
            _photoManager = photoManager;
        }

        [HttpPost("UploadPreviewPhotos")]
        public async Task<ActionResult<PhotoResponse>> UploadPreviewPhotos(List<IFormFile> photos)
        {
            //var response = await _photoManager.SavePhotoAsync(photos);

            return Ok(/*response*/);
        }
    }
}
