using Application.Models;
using HousingReservation.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public interface IPhotoManager
    {
        List<Photo> SavePhotoOnDisk(List<IFormFile> files);
        void DeletePhotosFromDisk(List<Photo> photos);
    }
}
