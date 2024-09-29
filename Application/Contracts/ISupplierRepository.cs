using PhoneStore.Application.Contracts.Common;
using PhoneStore.Domain.Models;

namespace PhoneStore.Application.Contracts
{
    public interface ISupplierRepository : IGenericRepository<Supplier>
    {
        Task<Supplier> GetByIdAsync(string supplierName);
    }
}
