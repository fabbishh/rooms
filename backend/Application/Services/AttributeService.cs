using Domain.Common;
using Domain.Entities;
using HousingReservation.Domain.Common;
using HousingReservation.Domain.Entities;
using HousingReservation.Domain.Sanatoriums;
using MediatR;

namespace Application.Services
{
    public class AttributeService : IAttributeService
    {
        private readonly IRoomAttributeRepository _roomAttributeRepository;
        private readonly ISanatoriumAttributeRepository _sanatoriumAttributeRepository;
        private readonly ISanatoriumRepository _sanatoriumRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AttributeService(
            IRoomAttributeRepository roomAttributeRepository,
            ISanatoriumAttributeRepository sanatoriumAttributeRepository,
            ISanatoriumRepository sanatoriumRepository,
            IRoomRepository roomRepository,
            IUnitOfWork unitOfWork
            )
        {
            _roomAttributeRepository = roomAttributeRepository;
            _sanatoriumAttributeRepository = sanatoriumAttributeRepository;
            _sanatoriumRepository = sanatoriumRepository;
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task UpdateRoomAttributes(List<RoomAttribute> roomAttributes)
        {
            await UpdateEntityAttributes(roomAttributes, _roomAttributeRepository);
        }

        public async Task UpdateSanatoriumAttributes(List<SanatoriumAttribute> sanatoriumAttributes)
        {
            await UpdateEntityAttributes(sanatoriumAttributes, _sanatoriumAttributeRepository);
        }

        public async Task AddAttributeToSanatoriums(HousingReservation.Domain.Entities.Attribute attribute)
        {
            var sanatoriums = await _sanatoriumRepository.GetAllAsync();

            foreach (var sanatorium in sanatoriums)
            {
                await _sanatoriumAttributeRepository.AddAsync(new SanatoriumAttribute
                {
                    Id = Guid.NewGuid(),
                    AttributeId = attribute.Id,
                    IsActive = false,
                    DateCreated = DateTime.UtcNow,
                    SanatoriumId = sanatorium.Id,
                });
            }

            await _unitOfWork.SaveAsync();
        }

        public async Task AddAttributeToRoomGroups(HousingReservation.Domain.Entities.Attribute attribute)
        {
            var roomGroups = await _roomRepository.GetAllAsync();

            foreach (var group in roomGroups)
            {
                await _roomAttributeRepository.AddAsync(new RoomAttribute
                {
                    Id = Guid.NewGuid(),
                    AttributeId = attribute.Id,
                    IsActive = false,
                    DateCreated = DateTime.UtcNow,
                    RoomGroupId = group.Id,
                });
            }

            await _unitOfWork.SaveAsync();
        }

        private async Task UpdateEntityAttributes<TEntity, TRepository>(List<TEntity> attributes, TRepository repository) 
            where TEntity : BaseEntity, IEntityAttribute
            where TRepository : IBaseRepository<TEntity>
        {
            foreach (var updateAttribute in attributes)
            {
                var existingAttribute = await repository.GetByIdAsync(updateAttribute.Id);
                if (existingAttribute != null)
                {
                    existingAttribute.IsActive = updateAttribute.IsActive;
                    repository.Update(existingAttribute);
                } else
                {
                    await repository.AddAsync(updateAttribute);
                }
            }

            await _unitOfWork.SaveAsync();
        }


    }
}
