using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.CustomerPayment.Request.Query;

namespace PhoneStore.Application.Features.CustomerPayment.Handler.Query
{
    public class GetListOfCustomerPaymentsByCustomerIdRequestHandler : IRequestHandler<GetListOfCustomerPaymentsByCustomerIdRequest, List<CustomersPaymentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetListOfCustomerPaymentsByCustomerIdRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<CustomersPaymentDto>> Handle(GetListOfCustomerPaymentsByCustomerIdRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CustomersPaymentRepository.AllCustomerPaymentsById(request.Id);
        }
    }
}
