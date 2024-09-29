using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.Purchase.Request.Commands
{
    public class UpdatePurchaseCommand : IRequest<int>
    {
        public PurchaseDto PurchaseDto { get; set; }
    }
}
