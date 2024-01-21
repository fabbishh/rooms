using Application.Models;
using Domain.Enums;
using MediatR;

namespace Application.Queries
{
    public class GetUserListQuery : IRequest<List<UserModel>>
    {
        public Role? Role { get; set; }
    }
}
