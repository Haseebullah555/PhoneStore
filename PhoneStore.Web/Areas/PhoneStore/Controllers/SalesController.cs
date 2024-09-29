using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.Sale.Request.Commands;
using PhoneStore.Application.Features.Sale.Request.Queries;
using PhoneStore.Web.Models;

namespace PhoneStore.Web.Areas.PhoneStore.Controllers
{
    [Area("PhoneStore")]
    public class SalesController : Controller
    {
        private readonly IMediator _mediator;

        public SalesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult>Index()
        {
            return View();
        }
        public async Task<JsonResult> GetSales()
        {
            var sales = await _mediator.Send(new GetListOfSalesRequest());
            return Json(new {data = sales});
        }
        public async Task<JsonResult> GetSale(int id)
        {
            var sale = await _mediator.Send(new GetSaleByIdRequest { SaleId = id });
            return Json(new { data = sale });
        }
        [HttpPost]
        public async Task<JsonResult> EditSale(SalesDto salesDto)
        {
            if (ModelState.IsValid)
            {
                var sale = await _mediator.Send(new UpdateSaleCommand { SalesDto = salesDto });
                return Json(new { data = sale });
            }
            return Json(new { data = false });
        }
        [HttpGet]
        public async Task<IActionResult> CustomerLoanView ()
        {
            return View();
        }
        public async Task<JsonResult> CustomersLoan()
        {
            var loans = await _mediator.Send(new GetListOfCustomersLoanRequest());
            return Json(new { data = loans });
        }
        [HttpGet]
        public async Task<JsonResult> CustomersLoanDetails(string customerName)
        {
            var loanDetails = await _mediator.Send(new GetCustomersLoanDetailsRequest { CustomerName = customerName });
            return Json(new { data = loanDetails });
        }
    }
}
