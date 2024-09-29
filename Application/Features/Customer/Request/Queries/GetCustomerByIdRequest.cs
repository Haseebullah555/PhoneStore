using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.Customer.Request.Queries
{
    public class GetCustomerByIdRequest : IRequest<CustomerDto>
    {
        public int Id { get; set; }

    }
}
