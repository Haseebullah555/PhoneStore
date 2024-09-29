using Microsoft.EntityFrameworkCore;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Contracts.Common;
using PhoneStore.Application.Dtos;
using PhoneStore.Domain.Models;
using PhoneStore.Persistence.Database;
using PhoneStore.Persistence.Repositories.Common;

namespace PhoneStore.Persistence.Repositories
{
    public class CustomerPaymentRepository : GenericRepository<CustomersPayment>, ICustomersPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerPaymentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<CustomersPaymentDto>> AllCustomerPaymentsById(int id)
        {
            var paymentHistory = await (from payment in _context.CustomersPayments
                                        join customer in _context.Customers on payment.CustomerId equals customer.Id
                                        where payment.CustomerId == id
                                        select new CustomersPaymentDto
                                        {
                                            PaymentAmount = payment.PaymentAmount,
                                            CreatedDate = payment.CreatedDate,
                                            Customer = customer.CustomerName // Assuming you want to get the customer name
                                        }).ToListAsync();

            return paymentHistory;

        }
        public async Task<List<CustomersPaymentDto>> AllCustomersPaymentList()
        {
            var paymentHistory = await (from payment in _context.CustomersPayments
                                        join customer in _context.Customers on payment.CustomerId equals customer.Id
                                        select new CustomersPaymentDto
                                        {
                                            PaymentAmount = payment.PaymentAmount,
                                            CreatedDate = payment.CreatedDate,
                                            Customer = customer.CustomerName // Assuming you want to get the customer name
                                        }).ToListAsync();

            return paymentHistory;

        }
    }
}
