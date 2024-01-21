using Application.Models;
using Application.Queries;
using HousingReservation.Domain.Sanatoriums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class GetSanatoriumProfileDataQueryHandler : IRequestHandler<GetSanatoriumProfileDataQuery, SanatoriumProfileDataDto>
    {
        private readonly ISanatoriumRepository _sanatoriumRepository;
        public GetSanatoriumProfileDataQueryHandler(ISanatoriumRepository sanatoriumRepository)
        {
            _sanatoriumRepository = sanatoriumRepository;
        }
        public async Task<SanatoriumProfileDataDto> Handle(GetSanatoriumProfileDataQuery request, CancellationToken cancellationToken)
        {
            var sanatorium = await _sanatoriumRepository.GetByIdAsync(request.SanatoriumId);
            if (sanatorium == null) 
            {
                return null;
            }

            var mappedSanatorium = new SanatoriumProfileDataDto
            {
                Id = sanatorium.Id,
                Name = sanatorium.Name,
                CheckInTime = sanatorium.CheckInTime,
                CheckOutTime = sanatorium.CheckOutTime,
                Season = sanatorium.Season,
                Email = sanatorium.Email,
                Location = sanatorium.Location,
                ObjectType = sanatorium.TypeId,
                PhotoUrl = sanatorium.Photo?.OriginalUrl,
                OwnerId = sanatorium.OwnerId,
                SubjectId = sanatorium.SubjectId,
                Status = sanatorium.Status,
            };

            return mappedSanatorium;
        }
    }
}
