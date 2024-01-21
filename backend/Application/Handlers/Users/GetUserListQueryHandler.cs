using Application.Models;
using Application.Queries;
using Domain.Common;
using Domain.Enums;
using HousingReservation.Domain.Entities;
using MediatR;


namespace Application.Handlers.Users
{
    internal class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserModel>>
    {
        private readonly IUserRepository _userRepository;
        public GetUserListQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<UserModel>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            //поменять на админа санатория
            IEnumerable<User>? users = null;
            if(request.Role is not null)
            {
                users = await _userRepository.FindAsync(u => u.Role == request.Role && u.IsActive);
            }
            else
            {
                users = await _userRepository.GetAllAsync();
            }



            var mappedUsers = users.Select(u => new UserModel
            {
                Id = u.Id,
                DateCreated = u.DateCreated,
                Email = u.Email!,
                Phone = u.PhoneNumber,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Patronymic = u.Patronymic,
                IsActive = u.IsActive,
            }).ToList();

            return mappedUsers;
        }
    }
}
