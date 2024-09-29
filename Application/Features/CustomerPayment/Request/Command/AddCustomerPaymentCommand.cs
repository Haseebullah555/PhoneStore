using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.CustomerPayment.Request.Command
{
    public class AddCustomerPaymentCommand : IRequest<Unit>
    {
        public int CustomerId { get; set; }
        public int PaymentAmount { get; set; }
    }
}
