using Domain.Common;
using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;
using HousingReservation.Domain.Entities;

namespace DataAccess.Repositories
{
    public sealed class PhotoRepository : BaseRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(ReservationDbContext dbContext) : base(dbContext) { }
    }
}
