using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.Sale.Request.Queries;

namespace PhoneStore.Application.Features.Sale.Handler.Queries
{
    public class GetListOfSalesRequestHandler : IRequestHandler<GetListOfSalesRequest, List<SalesDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetListOfSalesRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<List<SalesDto>> Handle(GetListOfSalesRequest request, CancellationToken cancellationToken)
        {
            //   return _unitOfWork.SalesRepository.GetAllSales();
            return null;
        }
    }
}
