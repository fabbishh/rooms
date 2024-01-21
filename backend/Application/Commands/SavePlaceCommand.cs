using HousingReservation.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands
{
    public class SavePlaceCommand : IRequest
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid SubjectId { get; set; }
        public List<IFormFile>? Photos { get; set; }
        public List<Guid>? DeletedPhotos { get; set; }
    }
}
