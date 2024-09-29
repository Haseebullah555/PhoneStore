using MediatR;
using PhoneStore.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Application.Features.Customer.Request.Commands
{
    public class UpdateCustomerCommand : IRequest<int>
    {
        public CustomerDto CustomerDto { get; set; }
    }
}
