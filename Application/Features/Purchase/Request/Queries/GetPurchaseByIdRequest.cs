using MediatR;
using PhoneStore.Application.Dtos;
namespace PhoneStore.Application.Features.Purchase.Request.Queries
{
    public class GetPurchaseByIdRequest : IRequest<PurchaseDto>
    {
        public int Id { get; set; }
    }
}
