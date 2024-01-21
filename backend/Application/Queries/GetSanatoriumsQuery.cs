using Application.Models;
using MediatR;

namespace Application.Queries
{
    public class GetSanatoriumsQuery : IRequest<List<SelectItemModel>>
    {
    }
}
