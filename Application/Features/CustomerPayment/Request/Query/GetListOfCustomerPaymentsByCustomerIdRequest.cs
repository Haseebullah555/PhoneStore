using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.CustomerPayment.Request.Query
{
    public class GetListOfCustomerPaymentsByCustomerIdRequest : IRequest<List<CustomersPaymentDto>>
    {
        public int Id { get; set; }
    }
}
