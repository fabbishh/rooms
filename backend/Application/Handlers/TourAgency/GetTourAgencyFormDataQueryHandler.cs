using Application.Models;
using Application.Queries;
using Domain.Common;
using MediatR;

namespace Application.Handlers
{
    internal class GetTourAgencyFormDataQueryHandler : IRequestHandler<GetTourAgencyFormDataQuery, TourAgencyProfileData>
    {
        private readonly ITourAgencyRepository _tourAgencyRepository;
        public GetTourAgencyFormDataQueryHandler(ITourAgencyRepository tourAgencyRepository)
        {
            _tourAgencyRepository = tourAgencyRepository;
        }
        public async Task<TourAgencyProfileData> Handle(GetTourAgencyFormDataQuery request, CancellationToken cancellationToken)
        {
            var tourAgency = await _tourAgencyRepository.FindOneAsync(ta => ta.Id == request.TourAgencyId);

            if (tourAgency == null)
            {
                return null;
            }

            var mappedTourAgency = new TourAgencyProfileData
            {
                Id = tourAgency.Id,
                Name = tourAgency.Name,
                Description = tourAgency.Description,
                Email = tourAgency.Email,
                Link = tourAgency.Link,
                Location = tourAgency.Location,
                SubjectId = tourAgency.SubjectId,
                PhotoUrl = tourAgency.Photo?.OriginalUrl,
                Status = (int)tourAgency.Status,
                OwnerId = tourAgency.OwnerId
            };

            return mappedTourAgency;
        }
    }
}
