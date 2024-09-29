using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.Supplier.Request.Command
{
    public class UpdateSupplierCommand : IRequest<int>
    {
        public SupplierDto SupplierDto { get; set; }
    }
}
