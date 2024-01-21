using HousingReservation.Domain.Entities;

namespace Domain.Common
{
    public interface IHasPhoto
    {
        public List<Photo> Photos { get; set; }
    }
}
