using Microsoft.EntityFrameworkCore;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Domain.Models;
using PhoneStore.Persistence.Database;
using PhoneStore.Persistence.Repositories.Common;

namespace PhoneStore.Persistence.Repositories
{
    public class SupplierLoansRepository : GenericRepository<SupplierLoans>, ISupplierLoansRepository
    {
        private readonly ApplicationDbContext _context;

        public SupplierLoansRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<SupplierLoans> FindBySupplierAndGood(string supplierName)
        {
            return await _context.SupplierLoans
                             .FirstOrDefaultAsync(l => l.Supplier.SupplierName == supplierName);
        }
        public async Task<List<SupplierLoansDto>> GetSupplierLoans()
        {
            var supplierLoans = await (from supplierLoan in _context.SupplierLoans
                                       join supplier in _context.Suppliers on supplierLoan.SupplierId equals supplier.Id
                                       group supplierLoan by new {supplier.SupplierName } into loanGroup
                                       select new SupplierLoansDto
                                       {
                                           SupplierName = loanGroup.Key.SupplierName,
                                           UnpaidAmount = loanGroup.Sum(x => x.UnpaidAmount), // Sum the unpaid amounts for each supplier
                                                                                              // You can add more aggregated data if needed
                                       }).ToListAsync();
            return supplierLoans;
        }
    }
}
