using AutoMapper;
using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Features.Stock.Request.Command;

namespace PhoneStore.Application.Features.Stock.Handler.Command
{
    public class AddToStockCommandHandler : IRequestHandler<AddToStockCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddToStockCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Handle(AddToStockCommand request, CancellationToken cancellationToken)
        {
            var stock = _mapper.Map<Domain.Models.Stock>(request.StockDto);
            await _unitOfWork.StockRepository.Add(stock);
            await _unitOfWork.SaveChanges(cancellationToken);
            return stock.Id;
        }
    }
}
