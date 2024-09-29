using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.SupplierLoans.Request.Query;

namespace PhoneStore.Application.Features.SupplierLoans.Handler.Query
{
    public class GetListOfSupplierLoansRequestHandler : IRequestHandler<GetListOfSupplierLoansRequest, List<SupplierLoansDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetListOfSupplierLoansRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<SupplierLoansDto>> Handle(GetListOfSupplierLoansRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.SuppliersLoansRepository.GetSupplierLoans();
        }
    }
}
