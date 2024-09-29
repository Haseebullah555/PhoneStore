using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.SupplierPayments.Request.Query
{
    public class GetListOfSupplierPaymentsBySupplierIdRequest : IRequest<List<SuppliersPaymentDto>>
    {
        public int Id { get; set; }
    }
}
