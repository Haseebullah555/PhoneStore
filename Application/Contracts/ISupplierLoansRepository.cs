using PhoneStore.Application.Contracts.Common;
using PhoneStore.Application.Dtos;
using PhoneStore.Domain.Models;

namespace PhoneStore.Application.Contracts
{
    public interface ISupplierLoansRepository : IGenericRepository<SupplierLoans>
    {
        Task<List<SupplierLoansDto>> GetSupplierLoans();
        Task<SupplierLoans> FindBySupplierAndGood(string supplierName);
    }
}