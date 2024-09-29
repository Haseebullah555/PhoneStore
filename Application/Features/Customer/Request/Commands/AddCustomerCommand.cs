using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.Customer.Request.Commands
{
    public class AddCustomerCommand : IRequest<Unit>
    {
        public CustomerDto  CustomerDto { get; set; }
    }
}
