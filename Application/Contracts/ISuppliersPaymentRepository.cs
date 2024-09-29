using PhoneStore.Application.Contracts.Common;
using PhoneStore.Application.Dtos;
using PhoneStore.Domain.Models;

namespace PhoneStore.Application.Contracts
{
    public interface ISuppliersPaymentRepository : IGenericRepository<SuppliersPayment>
    {
        Task<List<SuppliersPaymentDto>> AllSupplierPaymentsById(int id);
        Task<List<SuppliersPaymentDto>> AllSuppliersPaymentList();
    }
}
