using MediatR;
using PhoneStore.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Application.Features.Customer.Request.Queries
{
    public class GetCustomerListRequest : IRequest<List<CustomerDto>>
    {
    }
}
