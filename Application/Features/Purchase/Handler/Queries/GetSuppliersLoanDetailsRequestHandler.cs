using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.Purchase.Request.Queries;

namespace PhoneStore.Application.Features.Purchase.Handler.Queries
{
    public class GetSuppliersLoanDetailsRequestHandler : IRequestHandler<GetSuppliersLoanDetailsRequest, List<PurchaseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSuppliersLoanDetailsRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<PurchaseDto>> Handle(GetSuppliersLoanDetailsRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.PurchaseRepository.GetSuppliersLoanDetails();
        }
    }
}
