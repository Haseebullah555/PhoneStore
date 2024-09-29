using PhoneStore.Application.Contracts.Common;
using PhoneStore.Application.Dtos;
using PhoneStore.Domain.Models;

namespace PhoneStore.Application.Contracts
{
    public interface ICustomerLoansRepository : IGenericRepository<CustomerLoans>
    {
        Task<List<CustomerLoansDto>> GetCustomerLoans(int id);
        Task<CustomerLoans> FindByCustomerAndGood(string customerName);
    }
}
