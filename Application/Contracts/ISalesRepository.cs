using PhoneStore.Application.Contracts.Common;
using PhoneStore.Application.Dtos;
using PhoneStore.Domain.Models;

namespace PhoneStore.Application.Contracts
{
    public interface ISalesRepository : IGenericRepository<Sales>
    {
        Task<List<SalesDto>> GetAllSales();
        Task<SalesDto> GetSale(int id);
        Task<List<SalesDto>> GetCustomersLoan();
        Task<List<SalesDto>> GetCustomersLoanDetails(string customerName);
        
    }
}
