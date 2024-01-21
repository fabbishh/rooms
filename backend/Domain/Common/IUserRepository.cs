﻿using HousingReservation.Domain.Common;
using HousingReservation.Domain.Entities;

namespace Domain.Common
{
    public interface IUserRepository : IPagedRepository<User>
    {
    }
}
