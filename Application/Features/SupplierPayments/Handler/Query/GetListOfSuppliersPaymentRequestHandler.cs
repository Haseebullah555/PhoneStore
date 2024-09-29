using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.SupplierPayments.Request.Query;

namespace PhoneStore.Application.Features.SupplierPayments.Handler.Query
{
    public class GetListOfSuppliersPaymentRequestHandler : IRequestHandler<GetListOfSuppliersPaymentRequest, List<SuppliersPaymentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetListOfSuppliersPaymentRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<SuppliersPaymentDto>> Handle(GetListOfSuppliersPaymentRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.SuppliersPaymentRepository.AllSuppliersPaymentList();
        }
    }
}
