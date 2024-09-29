using PhoneStore.Application.Contracts.Common;
using PhoneStore.Application.Dtos;
using PhoneStore.Domain.Models;

namespace PhoneStore.Application.Contracts
{
    public interface ICustomersPaymentRepository : IGenericRepository<CustomersPayment>
    {
        Task<List<CustomersPaymentDto>> AllCustomerPaymentsById(int id);
        Task<List<CustomersPaymentDto>> AllCustomersPaymentList();
        
    }
}
