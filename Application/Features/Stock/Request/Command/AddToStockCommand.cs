using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.Stock.Request.Command
{
    public class AddToStockCommand : IRequest<int>
    {
        public StockDto StockDto { get; set; }
    }
}
