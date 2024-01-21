using Application.Models;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands
{
    public class CreateRoomsCommand : IRequest
    {
        public string? Name { get; set; }
        public int SameRoomCount { get; set; }
        public int MinDaysReservation { get; set; }
        public int RoomType { get; set; }
        public int HousingType { get; set; }
        public int BedroomCount { get; set; }
        public int SingleBedCount { get; set; }
        public int DoubleBedCount { get; set; }
        public decimal PricePerNight { get; set; }
        public string Description { get; set; }
        public AdminRequestStatus Status { get; set; }
        public Guid SanatoriumId { get; set; }
        public List<RoomAttributeDto> ComfortAttributes { get; set; }
        public List<RoomAttributeDto> FoodAttributes { get; set; }
        public List<RoomAttributeDto> BathroomAttributes { get; set; }
        public List<IFormFile>? Photos { get; set; }
    }
}
