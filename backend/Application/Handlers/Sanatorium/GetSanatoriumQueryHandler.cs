using Application.Models;
using Application.Queries;
using AutoMapper;
using HousingReservation.Domain.Sanatoriums;
using MediatR;

namespace Application.Handlers
{
    public class GetSanatoriumQueryHandler : IRequestHandler<GetSanatoriumQuery, SanatoriumDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ISanatoriumRepository _sanatoriumRepository;
        public GetSanatoriumQueryHandler(IMapper mapper, ISanatoriumRepository sanatoriumRepository)
        {
            _mapper = mapper;
            _sanatoriumRepository = sanatoriumRepository;
        }

        public async Task<SanatoriumDetailsDto> Handle(GetSanatoriumQuery request, CancellationToken cancellationToken)
        {
            var sanatorium = await _sanatoriumRepository.GetByIdAsync(request.Id);
            var mappedSanatorium = _mapper.Map<SanatoriumDetailsDto>(sanatorium);

            if(sanatorium?.RoomGroups is not null)
            {
                foreach (var roomGroup in sanatorium?.RoomGroups!)
                {
                    var urls = roomGroup.Photos?.Select(p => p.OriginalUrl);
                    if (urls != null)
                    {
                        mappedSanatorium.PhotoUrls.AddRange(urls);
                    }
                }
            }
            

            return mappedSanatorium;
        }
    }
}
