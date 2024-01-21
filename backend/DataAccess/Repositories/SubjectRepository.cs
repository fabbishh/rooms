using Domain.Common;
using Domain.Entities;
using HousingReservation.DataAccess;
using HousingReservation.DataAccess.Repositories;

namespace DataAccess.Repositories
{
    public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(ReservationDbContext reservationDbContext) : base(reservationDbContext)
        {
        }
    }
}
