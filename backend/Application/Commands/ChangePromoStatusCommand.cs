using Domain.Enums;
using MediatR;

namespace Application.Commands
{
    public class ChangePromoStatusCommand : IRequest
    {
        public Guid PromoId { get; set; }
        public AdminRequestStatus Status { get; set; }
        public PromoType PromoType { get; set; }
    }
}
