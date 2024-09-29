using PhoneStore.Application.Contracts.Common;
using PhoneStore.Application.Dtos;
using PhoneStore.Domain.Models;

namespace PhoneStore.Application.Contracts
{
    public interface IStockRepository : IGenericRepository<Stock>
    {
        Task<List<StockDto>> GetAviliableItemsStock();
        Task<Stock> GetByGoodIdAsync(int goodId);
    }
}
