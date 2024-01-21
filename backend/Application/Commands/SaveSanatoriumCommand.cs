using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands
{
    public class SaveSanatoriumCommand : IRequest<Guid>
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public Guid ObjectType { get; set; }
        public string CheckInTime { get; set; }
        public string CheckOutTime { get; set; }
        public AdminRequestStatus Status { get; set; }
        public SanatoriumSeason Season { get; set; }
        public Guid OwnerId { get; set; }
        public Guid SubjectId { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
