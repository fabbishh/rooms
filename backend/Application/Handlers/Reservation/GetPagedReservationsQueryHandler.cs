using Application.Extensions;
using Application.Models;
using Application.Queries;
using Domain.Common;
using Domain.Enums;
using HousingReservation.Domain.Entities;
using HousingReservation.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class GetPagedReservationsQueryHandler : IRequestHandler<GetPagedReservationsQuery, PagedResult<ReservationsTableRow>?>
    {
        private readonly IRoomReservationRepository _roomReservationRepository;

        public GetPagedReservationsQueryHandler(IRoomReservationRepository roomReservationRepository)
        {
            _roomReservationRepository = roomReservationRepository;
        }

        public async Task<PagedResult<ReservationsTableRow>?> Handle(GetPagedReservationsQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                return null;
            }

            Expression<Func<RoomReservation, bool>>? filterExpression = null;
            if (request.Filter is not null)
            {
                if (request.Filter.SanatoriumId.HasValue)
                {
                    var sanatoriumId = request.Filter.SanatoriumId.Value;
                    Expression<Func<RoomReservation, bool>> sanatoriumFilter = s => s.Room.Group.SanatoriumId == sanatoriumId;

                    filterExpression = filterExpression == null
                        ? sanatoriumFilter
                        : filterExpression.And(sanatoriumFilter);
                }

                if (request.Filter.UserId.HasValue)
                {
                    var userId = request.Filter.UserId.Value;
                    Expression<Func<RoomReservation, bool>> userFilter = r => r.UserId == userId;

                    filterExpression = filterExpression == null
                        ? userFilter
                        : filterExpression.And(userFilter);
                }

                if (request.Filter.Activity.HasValue)
                {
                    var isActive = request.Filter.Activity.Value;
                    Expression<Func<RoomReservation, bool>> activityFilter = r => isActive ? r.StartDate > DateTimeOffset.UtcNow : r.StartDate <= DateTimeOffset.UtcNow;

                    filterExpression = filterExpression == null
                        ? activityFilter
                        : filterExpression.And(activityFilter);
                }

                if (request.Filter.Statuses is not null && request.Filter.Statuses.Any())
                {
                    var statuses = request.Filter.Statuses.Select(s => (AdminRequestStatus)s);
                    Expression<Func<RoomReservation, bool>> statusFilter = s => statuses.Contains(s.Status);

                    filterExpression = filterExpression == null
                        ? statusFilter
                        : filterExpression.And(statusFilter);
                }
            }

            var pagedResult = await _roomReservationRepository.GetPagedAsync(request.PageNumber, request.PageSize, filterExpression);

            var mappedReservations = pagedResult.Items.Select(r => new ReservationsTableRow
            {
                Id = r.Id,
                DateCreated = r.DateCreated,
                StartDate = r.StartDate,
                EndDate = r.EndDate,
                AuthorEmail = r.User?.Email,
                RoomName = $"{r.Room?.Group?.Name} {r.Room?.Name}",
                GuestsCount = r.AdultGuestsCount + r.ChildGuestsCount,
                Status = r.Status,
            }).ToList();

            return new PagedResult<ReservationsTableRow>(mappedReservations, pagedResult.TotalItems, pagedResult.PageNumber, pagedResult.PageSize);
        }
    }
}
