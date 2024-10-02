using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.Purchase.Request.Commands;
using PhoneStore.Application.Features.Purchase.Request.Queries;
using PhoneStore.Application.Features.Sale.Request.Queries;

namespace PhoneStore.Web.Areas.PhoneStore.Controllers
{
    [Area("PhoneStore")]
    public class PurchaseController : Controller
    {
        private readonly IMediator _mediator;

        public PurchaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetAllPurchases()
        {
            var Purchases = await _mediator.Send(new GetListOfPurchasesRequest());
            return Json(new {data = Purchases });
        }
        [HttpGet]
        public async Task<JsonResult> GetPurchase(int id)
        {
            var purchase = await _mediator.Send(new GetPurchaseByIdRequest { Id = id });
            return Json(new { data = purchase });
        }
        [HttpPost]
        public async Task<JsonResult> EditPurchase(PurchaseDto purchaseDto)
        {
            if (ModelState.IsValid)
           {
                var purchase = await _mediator.Send(new UpdatePurchaseCommand { PurchaseDto = purchaseDto });
                return Json(new { data = purchase });
            }
            return Json(new { data = false });
        }
        //public async Task<IActionResult> SupplierLoanView()
        //{
        //    return View();
        //}
        //public async Task<JsonResult> SuppliersLoan()
        //{
        //    var loans = await _mediator.Send(new GetListOfSuppliersLoanRequest());
        //    return Json(new { data = loans });
        //}
        //[HttpGet]
        //public async Task<JsonResult> SuppliersLoanDetails(int id)
        //{
        //    var loanDetails = await _mediator.Send(new GetSuppliersLoanDetailsRequest { Id = id });
        //    return Json(new { data = loanDetails });
        //}

    }
}
