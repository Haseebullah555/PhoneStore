using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.CustomerPayment.Request.Query
{
    public class GetListOfCustomersPaymentRequest : IRequest<List<CustomersPaymentDto>>
    {
    }
}
