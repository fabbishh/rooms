using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class GetPromoRowInfoQuery : IRequest<PromoInfo>
    {
        public Guid SanatoriumId { get; set; }
    }
}
