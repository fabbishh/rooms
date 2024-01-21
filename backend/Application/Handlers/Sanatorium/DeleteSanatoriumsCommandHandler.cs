using Application.Commands;
using Domain.Common;
using HousingReservation.Domain.Entities;
using HousingReservation.Domain.Sanatoriums;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Application.Handlers
{
    internal class DeleteSanatoriumsCommandHandler : IRequestHandler<DeleteSanatoriumsCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISanatoriumRepository _sanatoriumRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IFavouriteSanatoriumRepository _favouriteRpository;
        private readonly IRoomGroupRepository _roomGroupRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomReservationRepository _roomReservationRepository;
        private readonly IGuestsRepository _guestsRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IPromoRowItemRepository _promoRowItemRepository;
        private readonly IPromoBlockItemRepository _promoBlockItemRepository;
        private readonly ILogger<DeleteSanatoriumsCommandHandler> _logger;

        public DeleteSanatoriumsCommandHandler(
            IUnitOfWork unitOfWork, 
            ISanatoriumRepository sanatoriumRepository,
            ILogger<DeleteSanatoriumsCommandHandler> logger,
            IContactRepository contactRepository,
            IFavouriteSanatoriumRepository favouriteSanatoriumRepository,
            IRoomGroupRepository roomGroupRepository,
            IRoomRepository roomRepository,
            IRoomReservationRepository roomReservationRepository,
            IGuestsRepository guestsRepository,
            IReviewRepository reviewRepository,
            IPromoRowItemRepository promoRowItemRepository,
            IPromoBlockItemRepository promoBlockItemRepository)
        {
            _sanatoriumRepository = sanatoriumRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _contactRepository = contactRepository;
            _favouriteRpository = favouriteSanatoriumRepository;
            _roomGroupRepository = roomGroupRepository;
            _roomRepository = roomRepository;
            _roomReservationRepository = roomReservationRepository;
            _guestsRepository = guestsRepository;
            _reviewRepository = reviewRepository;
            _promoRowItemRepository = promoRowItemRepository;
            _promoBlockItemRepository = promoBlockItemRepository;
        }

        public async Task Handle(DeleteSanatoriumsCommand request, CancellationToken cancellationToken)
        {
            var sanatoriums = await _sanatoriumRepository.FindAsync(s => request.Ids.Contains(s.Id));

            if (!sanatoriums.Any())
            {
                return;
            }

            foreach (var item in sanatoriums)
            {
                _sanatoriumRepository.SetDeletedFlag(item);
            }
            var sanatoriumIds = sanatoriums.Select(s => s.Id).ToList();

            var promoBlockItems = await _promoBlockItemRepository.FindAsync(r => r.SanatoriumId.HasValue && sanatoriumIds.Contains(r.SanatoriumId.Value));
            foreach (var item in promoBlockItems)
            {
                _promoBlockItemRepository.SetDeletedFlag(item);
            }

            var promoRowItems = await _promoRowItemRepository.FindAsync(r => sanatoriumIds.Contains(r.SanatoriumId));
            foreach(var item in promoRowItems)
            {
                _promoRowItemRepository.SetDeletedFlag(item);
            }

            var reviews = await _reviewRepository.FindAsync(r => sanatoriumIds.Contains(r.SanatoriumId));
            foreach (var review in reviews)
            {
                _reviewRepository.SetDeletedFlag(review);
            }

            var contacts = await _contactRepository.FindAsync(c => c.SanatoriumId.HasValue && sanatoriumIds.Contains(c.SanatoriumId.Value));
            foreach (var contact in contacts)
            {
                _contactRepository.SetDeletedFlag(contact);
            }

            var favourites = await _favouriteRpository.FindAsync(f => sanatoriumIds.Contains(f.SanatoriumId));
            foreach (var favourite in favourites)
            {
                _favouriteRpository.SetDeletedFlag(favourite);
            }

            var roomGroups = await _roomGroupRepository.FindAsync(rg => sanatoriumIds.Contains(rg.SanatoriumId));
            foreach (var rg in roomGroups)
            {
                _roomGroupRepository.SetDeletedFlag(rg);
            }

            var rooms = await _roomRepository.FindAsync(r => roomGroups.Select(rg => rg.Id).Contains(r.GroupId));
            foreach (var room in rooms)
            {
                _roomRepository.SetDeletedFlag(room);
            }

            var pbi = await _promoBlockItemRepository.FindAsync(r => r.RoomId.HasValue && rooms.Select(r => r.Id).Contains(r.RoomId.Value));
            foreach (var item in pbi)
            {
                _promoBlockItemRepository.SetDeletedFlag(item);
            }

            var reservations = await _roomReservationRepository.FindAsync(rr => rooms.Select(r => r.Id).Contains(rr.RoomId));
            foreach (var res in reservations)
            {
                _roomReservationRepository.SetDeletedFlag(res);
            }

            var guests = await _guestsRepository.FindAsync(g => reservations.Select(r => r.Id).Contains(g.RoomReservationId));
            foreach (var guest in guests)
            {
                _guestsRepository.SetDeletedFlag(guest);
            }

            await _unitOfWork.SaveAsync();
            _logger.LogInformation("Удалены санатории: {@ids}", request.Ids);
        }
    }
}
