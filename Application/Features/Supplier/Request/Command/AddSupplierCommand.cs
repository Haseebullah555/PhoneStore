using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.Supplier.Request.Command
{
    public class AddSupplierCommand : IRequest<Unit>
    {
        public SupplierDto SupplierDto { get; set; }
    }
}
