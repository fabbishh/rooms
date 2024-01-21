using Application.Models;
using Application.Queries;
using Domain.Common;
using MediatR;

namespace Application.Handlers
{
    internal class GetRoomFormDataQueryHandler : IRequestHandler<GetRoomFormDataQuery, RoomFormData?>
    {
        private readonly IRoomGroupRepository _roomGroupRepository;
        private readonly IRoomAttributeRepository _roomAttributeRepository;
        public GetRoomFormDataQueryHandler(IRoomGroupRepository roomGroupRepository, IRoomAttributeRepository roomAttributeRepository)
        {
            _roomGroupRepository = roomGroupRepository;
            _roomAttributeRepository = roomAttributeRepository;
        }

        public async Task<RoomFormData?> Handle(GetRoomFormDataQuery request, CancellationToken cancellationToken)
        {
            var roomGroup = await _roomGroupRepository.GetByIdAsync(request.RoomGroupId);
            if (roomGroup is null)
            {
                return null;
            }

            var comfort = await _roomAttributeRepository.FindAsync(sa => sa.RoomGroupId == request.RoomGroupId
                                                            && sa.Attribute.AttributeGroup.Name == "RoomComfort");

            var mappedComfort = comfort.Select(a => new RoomAttributeDto
            {
                RoomAttributeId = a.Id,
                IsActive = a.IsActive,
                Name = a.Attribute.FriendlyName,
                AttributeId = a.AttributeId
            }).ToList();

            var food = await _roomAttributeRepository.FindAsync(sa => sa.RoomGroupId == request.RoomGroupId
                                                            && sa.Attribute.AttributeGroup.Name == "RoomFood");

            var mappedFood = food.Select(a => new RoomAttributeDto
            {
                RoomAttributeId = a.Id,
                IsActive = a.IsActive,
                Name = a.Attribute.FriendlyName,
                AttributeId = a.AttributeId
            }).ToList();

            var bath = await _roomAttributeRepository.FindAsync(sa => sa.RoomGroupId == request.RoomGroupId
                                                            && sa.Attribute.AttributeGroup.Name == "RoomBathroom");

            var mappedBath = bath.Select(a => new RoomAttributeDto
            {
                RoomAttributeId = a.Id,
                IsActive = a.IsActive,
                Name = a.Attribute.FriendlyName,
                AttributeId = a.AttributeId
            }).ToList();

            var roomFormData = new RoomFormData
            {
                Id = roomGroup.Id,
                Description = roomGroup.Description,
                DoubleBedCount = roomGroup.DoubleBedCount,
                MinDaysReservation = roomGroup.MinDaysReservation,
                BedroomCount = roomGroup.BedroomCount,
                Name = roomGroup.Name,
                Status = (int)roomGroup.Status,
                PricePerNight = roomGroup.PricePerNight,
                RoomType = (int)roomGroup.RoomType,
                SameRoomCount = roomGroup.Quantity,
                SanatoriumId = roomGroup.SanatoriumId,
                SingleBedCount = roomGroup.SingleBedCount,
                Photos = roomGroup.Photos.Select(p => new PhotoModel { Id = p.Id, Url = p.OriginalUrl }).ToList(),
                ComfortAttributes = mappedComfort,
                BathroomAttributes = mappedBath,
                FoodAttributes = mappedFood,
            };

            return roomFormData;
        }
    }
}
