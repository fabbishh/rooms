using Application.Models;
using HousingReservation.Domain.Models;
using MediatR;

namespace Application.Queries
{
    public class GetPagedSanatoriumsQuery : IRequest<PagedResult<SanatoriumDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public List<Guid>? ComfortAttributeIds { get; set; }
        public List<Guid>? ServiceAttributeIds { get; set; }
        public List<Guid>? FoodAttributeIds { get; set; }
        public List<Guid>? BathAttributeIds { get; set; }
        public List<int>? HousingTypes { get; set; }
        public List<int>? Seasons { get; set; }
        public List<int>? BedroomCounts { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public Guid? RegionId { get; set; }
        public Guid? UserId { get; set; }
    }
}
