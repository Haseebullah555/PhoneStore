using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.Stock.Request.Query
{
    public class GetListOfStockRequest : IRequest<List<StockDto>>
    {
    }
}
