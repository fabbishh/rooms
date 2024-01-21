using Application.Queries;
using HousingReservation.Domain.Sanatoriums;
using MediatR;

namespace Application.Handlers
{
    internal class GetSanatoriumDescriptionQueryHandler : IRequestHandler<GetSanatoriumDescriptionQuery, string?>
    {
        private readonly ISanatoriumRepository _sanatoriumRepository;
        public GetSanatoriumDescriptionQueryHandler(ISanatoriumRepository sanatoriumRepository)
        {
            _sanatoriumRepository = sanatoriumRepository;
        }
        public async Task<string?> Handle(GetSanatoriumDescriptionQuery request, CancellationToken cancellationToken)
        {
            var sanatorium = await _sanatoriumRepository.GetByIdAsync(request.SanatoriumId);
            if (sanatorium is null)
            {
                throw new InvalidOperationException("Санаторий не найден");
            }

            return sanatorium.Description;
        }
    }
}
