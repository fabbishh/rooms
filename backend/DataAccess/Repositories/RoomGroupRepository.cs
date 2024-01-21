using Domain.Common;
using Domain.Enums;
using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;
using HousingReservation.Domain.Entities;
using HousingReservation.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class RoomGroupRepository : PagedRepository<RoomGroup>, IRoomGroupRepository
    {
        public RoomGroupRepository(ReservationDbContext reservationDbContext) : base(reservationDbContext)
        {
        }

        public async Task<PagedResult<AdminRoomTable>> GetRoomTableData(int pageNumber, int pageSize, Guid? sanatoriumId, HousingType? housingType)
        {
            var query = _dbSet.AsQueryable().Where(r => !r.Deleted);
            if(sanatoriumId.HasValue)
            {
                query = query.Where(rg => rg.SanatoriumId == sanatoriumId);
            }
            if(housingType.HasValue)
            {
                query = query.Where(rg => rg.HousingType == housingType);
            }

            var totalItems = await query.CountAsync();

            var projection = query
                .Select(rg => new AdminRoomTable
                {
                    Name = rg.Name,
                    Price = rg.PricePerNight,
                    Count = rg.Rooms.Where(r => !r.Deleted).Count(),
                    RoomGroupId = rg.Id,
                    SanatoriumId = rg.SanatoriumId,
                    SanatoriumName = rg.Sanatorium.Name,
                    Status = rg.Status,
                    DateCreated = rg.DateCreated,
                });

            var items = await projection.Skip((pageNumber - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync();

            return new PagedResult<AdminRoomTable>(items, totalItems, pageNumber, pageSize);
        }

        public override async Task<RoomGroup?> GetByIdAsync(Guid id)
        {
            return await _dbSet
                .Include(rg => rg.Rooms.Where(r => !r.Deleted))
                .Include(rg => rg.Photos.Where(r => !r.Deleted))
                .Where(rg => !rg.Deleted && rg.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
