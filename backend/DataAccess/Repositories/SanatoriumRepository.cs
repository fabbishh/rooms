using HousingReservation.Domain.Entities;
using HousingReservation.Domain.Sanatoriums;
using Microsoft.EntityFrameworkCore;

namespace HousingReservation.DataAccess.Repositories
{
    public sealed class SanatoriumRepository : PagedRepository<Sanatorium>, ISanatoriumRepository
    {
        public SanatoriumRepository(ReservationDbContext dbContext) : base(dbContext) { }

        public override async Task<Sanatorium?> GetByIdAsync(Guid id)
        {
            return await _dbSet
                .Include(s => s.Photo)
                .Include(s => s.Owner)
                .Include(s => s.Subject)
                .Include(s => s.SanatoriumAttributes)
                .ThenInclude(sa => sa.Attribute)
                .ThenInclude(a => a.AttributeGroup)
                .Include(s => s.RoomGroups)
                .ThenInclude(rg => rg.Photos)
                .FirstOrDefaultAsync(s => s.Id == id && !s.Deleted);
        }

        protected override IQueryable<Sanatorium> PagedQuery()
        {
            return base.PagedQuery()
                .Include(s => s.Photo)
                .Include(s => s.Owner)
                .Include(s => s.Type)
                .Include(s => s.RoomGroups)
                .Include(s => s.Subject);
        }
    }
}
