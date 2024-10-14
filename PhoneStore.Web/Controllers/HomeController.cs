using Microsoft.AspNetCore.Mvc;
using PhoneStore.Application.Dtos;
using PhoneStore.Persistence.Database;
using PhoneStore.Web.Models;
using System.Diagnostics;

namespace PhoneStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _context;

		public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _context = dbContext;
        }

        public IActionResult Index()
        {
			//ViewBag.Sales = _context.Sales.Where(s => s.CreatedDate.Date == DateTime.UtcNow.Date).Sum(s=> s.TotalPrice);
   //         ViewBag.CashSales = _context.Sales.Where(s => s.PaidAmount > 0 && s.CreatedDate.Date == DateTime.UtcNow.Date).Sum(s => s.PaidAmount);
   //         ViewBag.LoanSales = _context.Sales.Where(s => s.UnPaidAmount > 0 && s.CreatedDate.Date == DateTime.UtcNow.Date).Sum(s => s.UnPaidAmount);
			//ViewBag.Purchases = _context.Purchases.Where(s => s.CreatedDate.Date == DateTime.UtcNow.Date).Sum(s=> s.TotalPrice);
   //         ViewBag.CashPurchases = _context.Purchases.Where(p => p.PaidAmount > 0 && p.CreatedDate.Date == DateTime.UtcNow.Date).Sum(p => p.PaidAmount);
   //         ViewBag.LoanPurchases = _context.Purchases.Where(p => p.UnPaidAmount > 0 && p.CreatedDate.Date == DateTime.UtcNow.Date).Sum(p => p.UnPaidAmount);
			//ViewBag.OutOfStockCount = _context.Stocks.Count(s => s.Quantity < 100);
			//ViewBag.ExtraExpenses = _context.ExtraExpenses.Sum(e => e.Quantity);

			return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
