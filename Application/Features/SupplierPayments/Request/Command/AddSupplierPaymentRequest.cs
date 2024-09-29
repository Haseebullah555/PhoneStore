using MediatR;
using PhoneStore.Application.Dtos;
using PhoneStore.Domain.Models;

namespace PhoneStore.Application.Features.SupplierPayments.Request.Command
{
    public class AddSupplierPaymentRequest : IRequest<int>
    {
        public SuppliersPaymentDto SuppliersPaymentDto { get; set; }
    }
}
