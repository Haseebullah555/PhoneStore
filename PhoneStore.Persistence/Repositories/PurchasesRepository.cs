//using Microsoft.EntityFrameworkCore;
//using PhoneStore.Application.Contracts;
//using PhoneStore.Application.Dtos;
//using PhoneStore.Domain.Models;
//using PhoneStore.Persistence.Database;
//using PhoneStore.Persistence.Repositories.Common;

//namespace PhoneStore.Persistence.Repositories
//{
//    public class PurchasesRepository : GenericRepository<Purchase>, IPurchaseRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public PurchasesRepository(ApplicationDbContext dbContext) : base(dbContext)
//        {
//            _context = dbContext;
//        }

//        public async Task<List<PurchaseDto>> GetAllPurchases()
//        {
//            var purchases = await _context.Purchases
//                                 .Select(purchase => new PurchaseDto
//                                 {
//                                     Id = purchase.Id,
//                                     GoodId = purchase.GoodId,
//                                     Goods = purchase.Goods.GoodName,
//                                     SupplierId = purchase.SupplierId,
//                                     Supplier = purchase.Supplier.SupplierName,
//                                     PurchaseAmount = purchase.PurchaseAmount,
//                                     UnitPurchasePrice = purchase.UnitPurchasePrice,
//                                     TotalPrice = purchase.TotalPrice,
//                                     PaidAmount = purchase.PaidAmount,
//                                     UnPaidAmount = purchase.UnPaidAmount
//                                 }).ToListAsync();
//            return purchases;
//        }

//        public async Task<PurchaseDto> GetPurchaseById(int id)
//        {
//            var Purchase = await(from purchase in _context.Purchases
//                                  join good in _context.Goods on purchase.GoodId equals good.Id
//                                  join supplier in _context.Suppliers on purchase.SupplierId equals supplier.Id
//                                  where purchase.Id == id
//                                  select new PurchaseDto
//                                  {
//                                      Id = purchase.Id,
//                                      GoodId = good.Id,
//                                      Goods = good.GoodName,
//                                      SupplierId = supplier.Id,
//                                      Supplier = supplier.SupplierName,
//                                      PurchaseAmount = purchase.PurchaseAmount,
//                                      UnitPurchasePrice = purchase.UnitPurchasePrice,
//                                      TotalPrice = purchase.TotalPrice,
//                                      PaidAmount = purchase.PaidAmount,
//                                      UnPaidAmount = purchase.UnPaidAmount
//                                  }).FirstOrDefaultAsync();
//            return Purchase;
//        }
//        public async Task<List<PurchaseDto>> GetSuppliersLoan()
//        {
//            var SupplierLoan = await (from purhcase in _context.Purchases
//                                      where purhcase.UnPaidAmount > 0
//                                      group purhcase by new
//                                      {
//                                          purhcase.Supplier.SupplierName,      // Group by CustomerName
//                                      } into salesGroup
//                                      select new PurchaseDto
//                                      {
//                                          Supplier = salesGroup.Key.SupplierName, // Access the grouped customer name
//                                          UnPaidAmount = salesGroup.Sum(s => s.UnPaidAmount),
//                                      }).ToListAsync();

//            return SupplierLoan;
//        }
//        //public async Task<List<PurchaseDto>> GetSuppliersLoanDetails(int id)
//        //{
//        //    var SupplierLoan = await (from purchases in _context.Purchases
//        //                              where purchases.UnPaidAmount > 0 && purchases.SupplierId ==id
//        //                              select new PurchaseDto
//        //                              {
//        //                                  Id = purchases.Id,
//        //                                  Supplier = purchases.Supplier.SupplierName,
//        //                                  Goods = purchases.Goods.GoodName,
//        //                                  PurchaseAmount = purchases.PurchaseAmount,
//        //                                  UnitPurchasePrice = purchases.UnitPurchasePrice,
//        //                                  TotalPrice = purchases.TotalPrice,
//        //                                  PaidAmount = purchases.PaidAmount,
//        //                                  UnPaidAmount = purchases.UnPaidAmount,
//        //                              }).ToListAsync();
//        //    return SupplierLoan;
//        //}
//    }
//}
