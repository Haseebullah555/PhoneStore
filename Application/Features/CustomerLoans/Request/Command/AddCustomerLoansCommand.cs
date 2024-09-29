using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.CustomerLoans.Request.Command
{
    public class AddCustomerLoansCommand : IRequest<Unit>
    {
        public CustomerLoansDto CustomerLoansDto { get; set; }
    }
}
