using Application.Models;
using Domain.Common;
using HousingReservation.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Reflection.Emit;

namespace Application.Services
{
    public class PhotoManager : IPhotoManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _contentRootPath;

        public PhotoManager(
            IHostingEnvironment environment,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _contentRootPath = Path.Combine(environment.ContentRootPath, "Files");

            if (!Directory.Exists(_contentRootPath))
            {
                Directory.CreateDirectory(_contentRootPath);
            }
            
        }

        public List<Photo> SavePhotoOnDisk(List<IFormFile> files)
        {
            var savedPhotos = new List<Photo>();

            foreach (var file in files)
            {

                var fileModel = SavePhoto(file);

                var photoUrl = GetPhotoUrl(fileModel.UniqueName);

                var photo = new Photo
                {
                    Id = fileModel.Id,
                    OriginalUrl = photoUrl,
                    SmallUrl = photoUrl,
                    ThumbUrl = photoUrl,
                    Path = fileModel.Path,
                };

                savedPhotos.Add(photo);
            }

            return savedPhotos;
        }

        public void DeletePhotosFromDisk(List<Photo> photos)
        {
            foreach (var photo in photos)
            {
                if (System.IO.File.Exists(photo.Path))
                {
                    System.IO.File.Delete(photo.Path);
                }
            }
        }

        private string GetPhotoUrl(string fileName)
        {
            var baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            var url = Path.Combine(baseUrl, "Files" , fileName);

            return url; 
        }

        private FileModel SavePhoto(IFormFile file)
        {
            var fileId = Guid.NewGuid();
            var ext = Path.GetExtension(file.FileName);
            string uniqueFileName = $"{fileId}{ext}";

            string filePath = Path.Combine(_contentRootPath, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return new FileModel { Id = fileId, UniqueName = uniqueFileName , Path = filePath};
        }
    }
}
