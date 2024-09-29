using MediatR;
using PhoneStore.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Application.Features.CustomerLoans.Request.Query
{
    public class GetListOfCustomerLoansRequest : IRequest<List<CustomerLoansDto>>
    {
        public int Id { get; set; }
    }
}
