using MediatR;

namespace Application.Commands
{
    public class CreatePromoBlockItemCommand : IRequest
    {
        public int Days { get; set; }
        public Guid PromoBlockId { get; set; }
        public Guid? SanatoriumId { get; set; }
        public Guid? RoomId { get; set; }
        public Guid? TourId { get; set; }
        public Guid? TourAgencyId { get; set; }

        public bool HasMultipleValues()
        {
            int count = 0;

            if (SanatoriumId.HasValue)
                count++;

            if (RoomId.HasValue)
                count++;

            if (TourId.HasValue)
                count++;

            if (TourAgencyId.HasValue)
                count++;

            return count > 1;
        }
    }
}
