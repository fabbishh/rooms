using Application.Models;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands
{
    public class SaveTourCommand : IRequest
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Guid Type { get; set; }
        public int Days { get; set; }
        public int TouristCountFrom { get; set; }
        public int TouristCountTo { get; set; }
        public decimal? PriceByTourist { get; set; }
        public decimal? PriceByGroup { get; set; }
        public string Description { get; set; }
        public AdminRequestStatus? Status { get; set; }
        public Guid TourAgencyId { get; set; }
        public Guid Subject { get; set; }
        public List<TourStartDate> StartDates { get; set; }
        public List<IFormFile>? Photos { get; set; }
        public List<Guid>? DeletedPhotos { get; set; }
        public List<int> Seasons { get; set; } = new List<int>();
    }
}
