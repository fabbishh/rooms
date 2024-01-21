using Domain.Common;
using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;
using HousingReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class TourDateBookingRepository : BaseRepository<TourDateBooking>, ITourDateBookingRepository
    {
        public TourDateBookingRepository(ReservationDbContext reservationDbContext) : base(reservationDbContext)
        {
        }

        public async Task<int> GetTourDateBookingCount(Guid tourDateId)
        {
            return await _dbSet.CountAsync();
        }
    }
}
