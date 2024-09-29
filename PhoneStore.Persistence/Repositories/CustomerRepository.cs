using Microsoft.EntityFrameworkCore;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Domain.Models;
using PhoneStore.Persistence.Database;
using PhoneStore.Persistence.Repositories.Common;

namespace PhoneStore.Persistence.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerReposistory
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        public async Task<Customer> GetByCusomerName(string cusomerName)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.CustomerName == cusomerName);
        }
        public async Task<List<CustomerDto>> AllCustomers()
        {
            var Customers = await (from customer in _context.Customers
                                   join province in _context.Provinces on customer.ProvinceId equals province.Id
                                   select new CustomerDto
                                   {
                                       Id = customer.Id,
                                       CustomerName = customer.CustomerName,
                                       PhoneNumber = customer.PhoneNumber,
                                       Address = customer.Address,
                                       ProvinceId = customer.ProvinceId,
                                       Province = province.Name

                                   }).ToListAsync();
            return Customers;
        }

       
    }
}
