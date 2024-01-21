using Application.Models;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands
{
    public class SaveTourAgencyCommand : IRequest
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
        public string? Location { get; set; }
        public string? Link { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public AdminRequestStatus Status { get; set; }
        public IFormFile? Logo { get; set; }
        public Guid SubjectId { get; set; }
    }
}
