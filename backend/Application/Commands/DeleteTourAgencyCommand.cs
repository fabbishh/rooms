using MediatR;

namespace Application.Commands
{
    public class DeleteTourAgencyCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
    }
}
