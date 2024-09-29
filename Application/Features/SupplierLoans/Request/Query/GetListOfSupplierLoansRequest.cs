using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.SupplierLoans.Request.Query
{
    public class GetListOfSupplierLoansRequest : IRequest<List<SupplierLoansDto>>
    {
    }
}
