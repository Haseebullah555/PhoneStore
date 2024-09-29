using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.Supplier.Request.Queries
{
    public class GetSupplierByIdRequest : IRequest<SupplierDto>
    {
        public int Id { get; set; }
    }
}
