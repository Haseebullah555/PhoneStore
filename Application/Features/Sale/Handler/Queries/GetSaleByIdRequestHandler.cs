using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.Sale.Request.Queries;

namespace PhoneStore.Application.Features.Sale.Handler.Queries
{
    public class GetSaleByIdRequestHandler : IRequestHandler<GetSaleByIdRequest, SalesDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSaleByIdRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<SalesDto> Handle(GetSaleByIdRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.SalesRepository.GetSale(request.SaleId);
        }
    }
}
