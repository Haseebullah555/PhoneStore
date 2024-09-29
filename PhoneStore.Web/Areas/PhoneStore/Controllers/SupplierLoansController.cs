using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneStore.Application.Features.SupplierLoans.Request.Query;

namespace PhoneStore.Web.Areas.PhoneStore.Controllers
{
    [Area("PhoneStore")]
    public class SupplierLoansController : Controller
    {
        private readonly IMediator _mediator;

        public SupplierLoansController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> GetSupplierLoans()
        {
            var supplierLoans = await _mediator.Send(new GetListOfSupplierLoansRequest());
            return Json(new {data = supplierLoans});
        }
    }
}
