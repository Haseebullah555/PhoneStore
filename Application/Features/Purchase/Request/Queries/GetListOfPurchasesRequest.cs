using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.Purchase.Request.Queries
{
    public class GetListOfPurchasesRequest : IRequest<List<PurchaseDto>>
    {
    }
}
