using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.Sale.Request.Queries
{
    public class GetListOfSalesRequest : IRequest<List<SalesDto>>
    {
    }
}
