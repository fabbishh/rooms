using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class GetRolesQuery : IRequest<List<RoleModel>>
    {
    }
}
