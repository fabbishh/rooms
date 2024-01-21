using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class GetPromoBlocksInfoQuery : IRequest<List<PromoInfo>>
    {
        public Guid? SanatoriumId { get; set; }
        public Guid? RoomId { get; set; }
        public Guid? TourAgencyId { get; set; }
        public Guid? TourId { get; set; }
    }
}
