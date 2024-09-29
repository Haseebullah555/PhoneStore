using Microsoft.EntityFrameworkCore;
using PhoneStore.Application.Contracts;
using PhoneStore.Domain.Models;
using PhoneStore.Persistence.Database;
using PhoneStore.Persistence.Repositories.Common;

namespace PhoneStore.Persistence.Repositories
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        private readonly ApplicationDbContext _context;

        public SupplierRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<Supplier> GetByIdAsync(string supplierName)
        {
            return await _context.Suppliers
                                      .FirstOrDefaultAsync(s => s.SupplierName == supplierName);
        }
    }
}
