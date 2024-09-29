using Microsoft.EntityFrameworkCore;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Domain.Models;
using PhoneStore.Persistence.Database;
using PhoneStore.Persistence.Repositories.Common;

namespace PhoneStore.Persistence.Repositories
{
    public class CustomerLoansRepository : GenericRepository<CustomerLoans>, ICustomerLoansRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerLoansRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<CustomerLoans> FindByCustomerAndGood(string customerName)
        {
            return await _context.CustomerLoans
                             .FirstOrDefaultAsync(l => l.Customer.CustomerName == customerName);
        }

        public async Task<List<CustomerLoansDto>> GetCustomerLoans(int id)
        {
            var customerLoans = await (from customerLoan in _context.CustomerLoans
                                       join customer in _context.Customers on customerLoan.CustomerId equals customer.Id
                                       where customerLoan.CustomerId == id
                                       select new CustomerLoansDto
                                       {
                                           Id = customerLoan.Id,
                                           CustomerId = customerLoan.CustomerId,
                                           CustomerName = customer.CustomerName,
                                           UnpaidAmount = customerLoan.UnpaidAmount

                                       }).ToListAsync();
            return customerLoans;
        }
    }
}
