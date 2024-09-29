using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.Stock.Request.Query;

namespace PhoneStore.Application.Features.Stock.Handler.Query
{
    public class GetListOfStockRequestHandler : IRequestHandler<GetListOfStockRequest, List<StockDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetListOfStockRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<StockDto>> Handle(GetListOfStockRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.StockRepository.GetAviliableItemsStock();
        }
    }
}
