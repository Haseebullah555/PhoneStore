using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.Sale.Request.Queries
{
    public class GetListOfCustomersLoanRequest : IRequest<List<SalesDto>>
    {
    }
}
