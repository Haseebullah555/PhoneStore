using PhoneStore.Application.Contracts.Common;
using PhoneStore.Application.Dtos;
using PhoneStore.Domain.Models;

namespace PhoneStore.Application.Contracts
{
    public interface IPurchaseRepository : IGenericRepository<Purchase>
    {
        Task<List<PurchaseDto>> GetAllPurchases();
        Task<PurchaseDto> GetPurchaseById(int id);
        Task<List<PurchaseDto>> GetSuppliersLoan();
        //Task<List<PurchaseDto>> GetSuppliersLoanDetails(int id);
        
    }
}
