using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.Sale.Request.Queries;

namespace PhoneStore.Application.Features.Sale.Handler.Queries
{
    public class GetListOfCustomersLoanRequestHandler : IRequestHandler<GetListOfCustomersLoanRequest, List<SalesDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetListOfCustomersLoanRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<SalesDto>> Handle(GetListOfCustomersLoanRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.SalesRepository.GetCustomersLoan();
        }
    }
}
