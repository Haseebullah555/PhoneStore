using AutoMapper;
using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Features.SupplierPayments.Request.Command;

namespace PhoneStore.Application.Features.SupplierPayments.Handler.Command
{
    public class AddSupplierPaymentRequestHandler : IRequestHandler<AddSupplierPaymentRequest, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddSupplierPaymentRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Handle(AddSupplierPaymentRequest request, CancellationToken cancellationToken)
        {
            var payment = _mapper.Map<Domain.Models.SuppliersPayment>(request.SuppliersPaymentDto);
            await _unitOfWork.SuppliersPaymentRepository.Add(payment);
            await _unitOfWork.SaveChanges(cancellationToken);
            return payment.Id;
        }
    }
}
