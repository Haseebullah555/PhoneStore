using Microsoft.EntityFrameworkCore;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Domain.Models;
using PhoneStore.Persistence.Database;
using PhoneStore.Persistence.Repositories.Common;

namespace PhoneStore.Persistence.Repositories
{
    public class SalesRepository : GenericRepository<Sales>, ISalesRepository
    {
        private readonly ApplicationDbContext _context;

        public SalesRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<SalesDto>> GetAllSales()
        {
            var AllSales = await (from sales in _context.Sales
                                  join customer in _context.Customers on sales.CustomerId equals customer.Id
                                  join province in _context.Provinces on sales.Customer.ProvinceId equals province.Id
                                  select new SalesDto
                                  {
                                      Id = sales.Id,
                                      SaleAmount = sales.SaleAmount,
                                      SaleUnitPrice = sales.SaleUnitPrice,
                                      TotalPrice = sales.TotalPrice,
                                      PaidAmount = sales.PaidAmount,
                                      UnPaidAmount = sales.UnPaidAmount,
                                      GoodId = sales.GoodId,
                                      GoodName = sales.Goods.GoodName,
                                      CustomerId = sales.CustomerId,
                                      Customer = customer.CustomerName,
                                      ProvinceId = customer.ProvinceId,
                                      ProvinceName = customer.Province.Name

                                  }).ToListAsync();
            return AllSales;
        }
        public async Task<SalesDto> GetSale(int id)
        {
            var Sales= await (from sales in _context.Sales
                                  join customer in _context.Customers on sales.CustomerId equals customer.Id
                                  join province in _context.Provinces on sales.Customer.ProvinceId equals province.Id
                                  where sales.Id == id
                                  select new SalesDto
                                  {
                                      Id = sales.Id,
                                      SaleAmount = sales.SaleAmount,
                                      SaleUnitPrice = sales.SaleUnitPrice,
                                      TotalPrice = sales.TotalPrice,
                                      PaidAmount = sales.PaidAmount,
                                      UnPaidAmount = sales.UnPaidAmount,
                                      GoodId = sales.GoodId,
                                      GoodName = sales.Goods.GoodName,
                                      CustomerId = sales.CustomerId,
                                      Customer = customer.CustomerName,
                                      ProvinceId = customer.ProvinceId,
                                      ProvinceName = customer.Province.Name

                                  }).FirstOrDefaultAsync();
            return Sales;
        }

        public async Task<List<SalesDto>> GetCustomersLoan()
        {
            var CustomerLoan = await (from sales in _context.Sales
                                      join customer in _context.Customers on sales.CustomerId equals customer.Id
                                      join province in _context.Provinces on customer.ProvinceId equals province.Id
                                      where sales.UnPaidAmount > 0
                                      group sales by new
                                      {
                                          customer.CustomerName,          // Group by CustomerName
                                          customer.ProvinceId,            // Keep ProvinceId in the group key
                                          province.Name                   // ProvinceName in the group key
                                      } into salesGroup
                                      select new SalesDto
                                      {
                                          Customer = salesGroup.Key.CustomerName,   // Access the grouped customer name
                                          ProvinceId = salesGroup.Key.ProvinceId,   // Access the grouped province ID
                                          ProvinceName = salesGroup.Key.Name,       // Access the grouped province name
                                          UnPaidAmount = salesGroup.Sum(s => s.UnPaidAmount),
                                          Id = salesGroup.OrderBy(s => s.CreatedDate)
                                                        .FirstOrDefault().Id // Get earliest SalesId (FIFO)
                                      }).ToListAsync();
            return CustomerLoan;
        }
        //public async Task<List<SalesDto>> GetCustomersLoanDetails(string customerName)
        //{
        //    var CustomerLoan = await (from sales in _context.Sales
        //                              join province in _context.Provinces on sales.Customer.ProvinceId equals province.Id
        //                              where sales.UnPaidAmount > 0 && sales.Customer.CustomerName == customerName
        //                              select new SalesDto
        //                              {
        //                                  Id = sales.Id,
        //                                  Customer = sales.Customer.CustomerName,
        //                                  CustomerId = sales.CustomerId,
        //                                  GoodName = sales.Goods.GoodName,
        //                                  SaleAmount = sales.SaleAmount,
        //                                  SaleUnitPrice = sales.SaleUnitPrice,
        //                                  TotalPrice = sales.TotalPrice,
        //                                  PaidAmount = sales.PaidAmount,
        //                                  UnPaidAmount = sales.UnPaidAmount,
        //                                  ProvinceId = sales.Customer.ProvinceId,
        //                                  ProvinceName = province.Name
        //                              }).ToListAsync();
        //    return CustomerLoan;
        //}
    }
}
