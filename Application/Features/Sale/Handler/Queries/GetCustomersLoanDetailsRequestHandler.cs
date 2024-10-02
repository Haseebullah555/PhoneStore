//using MediatR;
//using PhoneStore.Application.Contracts;
//using PhoneStore.Application.Dtos;
//using PhoneStore.Application.Features.Sale.Request.Queries;

//namespace PhoneStore.Application.Features.Sale.Handler.Queries
//{
//    public class GetCustomersLoanDetailsRequestHandler : IRequestHandler<GetCustomersLoanDetailsRequest, List<SalesDto>>
//    {
//        private IUnitOfWork _unitOfWork;

//        public GetCustomersLoanDetailsRequestHandler(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }
//        public async Task<List<SalesDto>> Handle(GetCustomersLoanDetailsRequest request, CancellationToken cancellationToken)
//        {
//            return await _unitOfWork.SalesRepository.GetCustomersLoanDetails(request.CustomerName);
//        }
//    }
//}
