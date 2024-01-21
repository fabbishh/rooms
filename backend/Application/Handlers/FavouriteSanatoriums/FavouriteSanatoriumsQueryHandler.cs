using Application.Extensions;
using Application.Models;
using Application.Queries;
using Domain.Common;
using Domain.Entities;
using Domain.Enums;
using HousingReservation.Domain.Entities;
using HousingReservation.Domain.Models;
using HousingReservation.Domain.Sanatoriums;
using MediatR;
using System.Linq.Expressions;

namespace Application.Handlers.FavouriteSanatoriums
{
    internal class FavouriteSanatoriumsQueryHandler : IRequestHandler<FavouriteSanatoriumsQuery, PagedResult<SanatoriumDto>>
    {
        private readonly IFavouriteSanatoriumRepository _favouriteSanatoriumRepository;
        public FavouriteSanatoriumsQueryHandler(IFavouriteSanatoriumRepository favouriteSanatoriumRepository)
        {
            _favouriteSanatoriumRepository = favouriteSanatoriumRepository;
        }
        public async Task<PagedResult<SanatoriumDto>> Handle(FavouriteSanatoriumsQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<FavouriteSanatorium, bool>>? filterExpression = null;

            Expression<Func<FavouriteSanatorium, bool>> userFilter = s => s.UserId == request.UserId;
            filterExpression = filterExpression == null
                ? userFilter
                : filterExpression.And(userFilter);

            var pagedResult = await _favouriteSanatoriumRepository.GetPagedAsync(
                request.PageNumber,
                request.PageSize,
                filterExpression);

            var mappedItems = pagedResult.Items.Select(i => new SanatoriumDto
            {
                Id = i.SanatoriumId,
                Season = (int)i.Sanatorium.Season,
                Address = i.Sanatorium.Location,
                SubjectId = i.Sanatorium.SubjectId,
                Name = i.Sanatorium.Name,
                SubjectName = i.Sanatorium.Subject.Name,
                PriceFrom = i.Sanatorium.RoomGroups.Select(rg => rg.PricePerNight).OrderBy(p => p).FirstOrDefault(),
                PhotoUrl = i.Sanatorium.Photo == null ? "" : i.Sanatorium.Photo.OriginalUrl,
                IsFavourite = true
            }).ToList();

            return new PagedResult<SanatoriumDto>(mappedItems, pagedResult.TotalItems, pagedResult.PageNumber, pagedResult.PageSize);
        }
    }
}
