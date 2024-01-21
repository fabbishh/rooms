using Domain.Common;
using HousingReservation.DataAccess;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReservationDbContext _context;
        public UnitOfWork(ReservationDbContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
