using AutoMapper;
using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Features.Customer.Request.Commands;
using PhoneStore.Domain.Models;

namespace PhoneStore.Application.Features.Customer.Handler.Commands
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            var Customer = _mapper.Map<Domain.Models.Customer>(request.CustomerDto);
            var existingCustomer = await _unitOfWork.CustomerReposistory.GetByCusomerName(Customer.CustomerName);
            if (existingCustomer == null)
            {
                await _unitOfWork.CustomerReposistory.Add(Customer);
                await _unitOfWork.SaveChanges(cancellationToken);
                request.CustomerDto.Id = Customer.Id;
            }
            else
            {
                await _unitOfWork.CustomerReposistory.Update(Customer);
                await _unitOfWork.SaveChanges(cancellationToken);
                request.CustomerDto.Id = existingCustomer.Id;
            }
            // Process Sales and udate stock
            foreach (var sale in Customer.Sales)
            {
                var stockItem = await _unitOfWork.StockRepository.GetByGoodIdAsync(sale.GoodId);
                if(stockItem != null)
                {
                    stockItem.Quantity -= sale.SaleAmount;
                    await _unitOfWork.StockRepository.Update(stockItem);
                }
                else
                {
                    var newStock = new Domain.Models.Stock
                    {
                        GoodId = sale.GoodId,
                        Quantity = sale.SaleAmount
                    };
                    await _unitOfWork.StockRepository.Add(newStock);
                }
            }
            // Calculate total unpaid amount from the customer's sales
            var totalUnpaidAmount = request.CustomerDto.Sales
                .Where(s => s.UnPaidAmount > 0)
                .Sum(s => s.UnPaidAmount);
            // Check if an entry already exists in CustomerLoans
            var customerLoan = await _unitOfWork.CustomerLoansRepository
                .FindByCustomerAndGood(request.CustomerDto.CustomerName);
            if (customerLoan != null)
            {
                // Update the existing loan record
                customerLoan.UnpaidAmount += totalUnpaidAmount;
                await _unitOfWork.CustomerLoansRepository.Update(customerLoan);
            }
            else
            {
                var newCustmoerLoan = new Domain.Models.CustomerLoans
                {
                    CustomerId = request.CustomerDto.Id,
                    UnpaidAmount = totalUnpaidAmount,
                };
                await _unitOfWork.CustomerLoansRepository .Add(newCustmoerLoan);
            }
            await _unitOfWork.SaveChanges(cancellationToken);
            return Unit.Value;
        }
    }
}
