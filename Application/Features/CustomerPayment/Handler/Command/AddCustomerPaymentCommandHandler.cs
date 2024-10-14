//using AutoMapper;
//using MediatR;
//using PhoneStore.Application.Contracts;
//using PhoneStore.Application.Features.CustomerPayment.Request.Command;
//using PhoneStore.Domain.Models;

//namespace PhoneStore.Application.Features.CustomerPayment.Handler.Command
//{
//    public class AddCustomerPaymentCommandHandler : IRequestHandler<AddCustomerPaymentCommand, Unit>
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IMapper _mapper;

//        public AddCustomerPaymentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
//        {
//            _unitOfWork = unitOfWork;
//            _mapper = mapper;
//        }
//        public async Task<Unit> Handle(AddCustomerPaymentCommand request, CancellationToken cancellationToken)
//        {
//            var unpaidSales = await _unitOfWork.SalesRepository.GetCustomersLoan();

//            // Process the payment
//            int paymentAmount = request.PaymentAmount;

//            foreach (var saleDto in unpaidSales)
//            {
//                if (paymentAmount <= 0)
//                    break;

//                // You would need to get the original Sales entity if you need to update it
//                var sale = await _unitOfWork.SalesRepository.Get(saleDto.Id); // Assuming you have a method for this

//                // Calculate how much can be applied to this sale
//                int amountToApply = Math.Min(paymentAmount, sale.UnPaidAmount);

//                // Update sale with applied payment
//                sale.PaidAmount += amountToApply;
//                sale.UnPaidAmount -= amountToApply;

//                // Deduct the applied amount from the total payment
//                paymentAmount -= amountToApply;

//                // Update the sale in the repository
//                _unitOfWork.SalesRepository.Update(sale);
//            }

//            // Map request to payment record
//            var paymentRecord = _mapper.Map<CustomersPayment>(request);

//            // Save the payment record in the Payments table
//            await _unitOfWork.CustomersPaymentRepository.Add(paymentRecord);
//            await _unitOfWork.SaveChanges(cancellationToken);

//            return Unit.Value;
//        }
//    }
//}