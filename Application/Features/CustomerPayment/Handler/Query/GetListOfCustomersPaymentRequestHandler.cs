using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.CustomerPayment.Request.Query;

namespace PhoneStore.Application.Features.CustomerPayment.Handler.Query
{
    public class GetListOfCustomersPaymentRequestHandler : IRequestHandler<GetListOfCustomersPaymentRequest, List<CustomersPaymentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetListOfCustomersPaymentRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<CustomersPaymentDto>> Handle(GetListOfCustomersPaymentRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CustomersPaymentRepository.AllCustomersPaymentList();
        }
    }
}
