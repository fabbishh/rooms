using MediatR;

namespace Application.Commands
{
    public class CreatePromoRowItemCommand : IRequest
    {
        public Guid SanatoriumId { get; set; }
        public Guid PlanId { get; set; }
    }
}
