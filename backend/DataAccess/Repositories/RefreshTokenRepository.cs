using Domain.Common;
using Domain.Entities;
using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;

namespace DataAccess.Repositories
{
    public class RefreshTokenRepository : BaseRepository<UserRefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(ReservationDbContext reservationDbContext) : base(reservationDbContext)
        {
        }
    }
}
