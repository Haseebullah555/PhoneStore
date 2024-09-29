using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.Sale.Request.Queries
{
    public class GetCustomersLoanDetailsRequest : IRequest<List<SalesDto>>
    {
        public string CustomerName { get; set; }
    }
}
