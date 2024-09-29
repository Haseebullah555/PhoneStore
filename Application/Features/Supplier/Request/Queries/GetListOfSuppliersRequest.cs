using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.Supplier.Request.Queries
{
    public class GetListOfSuppliersRequest : IRequest<List<SupplierDto>>
    {
    }
}
