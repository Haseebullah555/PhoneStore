using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.SupplierPayments.Request.Query;

namespace PhoneStore.Application.Features.SupplierPayments.Handler.Query
{
    public class GetListOfSupplierPaymentsBySupplierIdRequestHandler : IRequestHandler<GetListOfSupplierPaymentsBySupplierIdRequest, List<SuppliersPaymentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetListOfSupplierPaymentsBySupplierIdRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<SuppliersPaymentDto>> Handle(GetListOfSupplierPaymentsBySupplierIdRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.SuppliersPaymentRepository.AllSupplierPaymentsById(request.Id);
        }
    }
}
