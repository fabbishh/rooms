using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class GetUserProfileQuery : IRequest<UserModel?>
    {
        public Guid UserId { get; set; }
    }
}
