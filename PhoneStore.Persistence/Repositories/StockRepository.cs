using Microsoft.EntityFrameworkCore;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Domain.Models;
using PhoneStore.Persistence.Database;
using PhoneStore.Persistence.Repositories.Common;

namespace PhoneStore.Persistence.Repositories
{
    public class StockRepository : GenericRepository<Stock>, IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<StockDto>> GetAviliableItemsStock()
        {
            var stocks = await (from stock in _context.Stocks
                                join goods in _context.Goods on stock.GoodId equals goods.Id
                                where stock.Quantity > 0
                                select new StockDto
                                {
                                    Id = stock.Id,
                                    GoodId = goods.Id,
                                    GoodName = goods.GoodName,
                                    CompanyName = goods.Company.CompanyName,
                                    Quantity = stock.Quantity,
                                }).ToListAsync();
            return stocks;
        }

        public async Task<Stock> GetByGoodIdAsync(int goodId)
        {
            return await _context.Stocks.FirstOrDefaultAsync(s => s.GoodId == goodId);
        }
    }
}
