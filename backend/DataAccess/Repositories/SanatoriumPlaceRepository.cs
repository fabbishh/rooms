using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;
using HousingReservation.Domain.Common;
using HousingReservation.Domain.Entities;

namespace DataAccess.Repositories
{
    public sealed class SanatoriumPlaceRepository : BaseRepository<SanatoriumPlace>, ISanatoriumPlaceRepository
    {
        public SanatoriumPlaceRepository(ReservationDbContext dbContext) : base(dbContext) { }
    }
}
