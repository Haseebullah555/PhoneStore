using Microsoft.EntityFrameworkCore;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Domain.Models;
using PhoneStore.Persistence.Database;
using PhoneStore.Persistence.Repositories.Common;

namespace PhoneStore.Persistence.Repositories
{
    public class GoodsRepository : GenericRepository<Goods>, IGoodsRepository
    {
        private readonly ApplicationDbContext _context;

        public GoodsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<GoodsDto>> GetAllGoods()
        {
            var good = await (from goods in _context.Goods
                               join company in _context.Companies on goods.CompanyId equals company.Id
                               select new GoodsDto 
                               {
                                   Id = goods.Id,
                                   GoodName = goods.GoodName,
                                   CompanyId = goods.CompanyId,
                                   Company = company.CompanyName
                               }).ToListAsync();
            return good;

        }
    }
}
