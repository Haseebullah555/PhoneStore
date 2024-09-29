using AutoMapper;
using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Features.Supplier.Request.Command;
using PhoneStore.Domain.Models;

namespace PhoneStore.Application.Features.Supplier.Handler.Command
{
    public class AddSupplierCommandHandler : IRequestHandler<AddSupplierCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddSupplierCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(AddSupplierCommand request, CancellationToken cancellationToken)
        {
            // Map the DTO to the Supplier entity
            var supplier = _mapper.Map<Domain.Models.Supplier>(request.SupplierDto);

            // Check if supplier exists
            var existingSupplier = await _unitOfWork.SupplierRepository.GetByIdAsync(supplier.SupplierName);
            if (existingSupplier == null)
            {
                await _unitOfWork.SupplierRepository.Add(supplier);
                await _unitOfWork.SaveChanges(cancellationToken);
                request.SupplierDto.Id = supplier.Id;
            }
            else
            {
                await _unitOfWork.SupplierRepository.Update(supplier);
                await _unitOfWork.SaveChanges(cancellationToken);
                request.SupplierDto.Id = existingSupplier.Id;
            }

            // Process purchases and update stock
            foreach (var purchase in supplier.Purchases)
            {
                var stockItem = await _unitOfWork.StockRepository.GetByGoodIdAsync(purchase.GoodId);
                if (stockItem != null)
                {
                    stockItem.Quantity += purchase.PurchaseAmount;
                    _unitOfWork.StockRepository.Update(stockItem);
                }
                else
                {
                    var newStock = new Domain.Models.Stock
                    {
                        GoodId = purchase.GoodId,
                        Quantity = purchase.PurchaseAmount
                    };
                    await _unitOfWork.StockRepository.Add(newStock);
                }
            }

            // Calculate total unpaid amount from the supplier's purchases
            var totalUnpaidAmount = request.SupplierDto.Purchases
                .Where(p => p.UnPaidAmount > 0)
                .Sum(p => p.UnPaidAmount);

            // Check if an entry already exists in SupplierLoans
            var supplierLoan = await _unitOfWork.SuppliersLoansRepository
                .FindBySupplierAndGood(request.SupplierDto.SupplierName);

            if (supplierLoan != null)
            {
                // Update the existing loan record
                supplierLoan.UnpaidAmount += totalUnpaidAmount;
                _unitOfWork.SuppliersLoansRepository.Update(supplierLoan);
            }
            else
            {
                // Create a new loan record
                var newSupplierLoan = new Domain.Models.SupplierLoans
                {
                    SupplierId = request.SupplierDto.Id,
                    UnpaidAmount = totalUnpaidAmount,
                };

                await _unitOfWork.SuppliersLoansRepository.Add(newSupplierLoan);
            }

            await _unitOfWork.SaveChanges(cancellationToken);
            return Unit.Value;
        }
    }
}
