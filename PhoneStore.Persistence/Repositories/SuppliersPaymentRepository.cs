using Microsoft.EntityFrameworkCore;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Domain.Models;
using PhoneStore.Persistence.Database;
using PhoneStore.Persistence.Repositories.Common;

namespace PhoneStore.Persistence.Repositories
{
    public class SuppliersPaymentRepository : GenericRepository<SuppliersPayment>, ISuppliersPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public SuppliersPaymentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<SuppliersPaymentDto>> AllSupplierPaymentsById(int id)
        {
            var paymentHistory = await (from payment in _context.SuppliersPayments
                                        join supplier in _context.Suppliers on payment.SupplierId equals supplier.Id
                                        where payment.SupplierId == id
                                        select new SuppliersPaymentDto
                                        {
                                            PaymentAmount = payment.PaymentAmount,
                                            CreatedDate = payment.CreatedDate,
                                            Supplier = supplier.SupplierName // Assuming you want to get the customer name
                                        }).ToListAsync();

            return paymentHistory;
        }
        public async Task<List<SuppliersPaymentDto>> AllSuppliersPaymentList()
        {
            var paymentHistory = await (from payment in _context.SuppliersPayments
                                        join supplier in _context.Suppliers on payment.SupplierId equals supplier.Id
                                        select new SuppliersPaymentDto
                                        {
                                            PaymentAmount = payment.PaymentAmount,
                                            CreatedDate = payment.CreatedDate,
                                            Supplier = supplier.SupplierName // Assuming you want to get the customer name
                                        }).ToListAsync();

            return paymentHistory;
        }
    }
}
