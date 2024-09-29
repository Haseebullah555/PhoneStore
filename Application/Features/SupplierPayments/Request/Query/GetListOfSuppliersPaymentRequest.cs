using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.SupplierPayments.Request.Query
{
    public class GetListOfSuppliersPaymentRequest : IRequest<List<SuppliersPaymentDto>>
    {
    }
}
