using Application.Models;
using Application.Queries;
using Domain.Common;
using MediatR;

namespace Application.Handlers
{
    internal class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, UserModel?>
    {
        private readonly IUserRepository _userRepository;
        public GetUserProfileQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserModel?> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user is null)
            {
                return null;
            }

            var mappedUser = new UserModel
            {
                Id = user.Id,
                DateCreated = user.DateCreated,
                FirstName = user.FirstName,
                Email = user.Email!,
                LastName = user.LastName,
                Gender = (int?)user.Gender,
                Patronymic = user.Patronymic,
                IsActive = user.IsActive,
                Phone = user.PhoneNumber,
                Birthday = user.Birthday,
                Role = user.Role
            };

            return mappedUser;
        }
    }
}
