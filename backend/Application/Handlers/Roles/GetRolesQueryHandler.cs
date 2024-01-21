using Application.Models;
using Application.Queries;
using MediatR;

namespace Application.Handlers.Roles
{
    internal class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, List<RoleModel>>
    {
        public Task<List<RoleModel>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
