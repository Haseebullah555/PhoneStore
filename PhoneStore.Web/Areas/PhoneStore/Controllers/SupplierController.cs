using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.Supplier.Request.Command;
using PhoneStore.Application.Features.Supplier.Request.Queries;

namespace PhoneStore.Web.Areas.PhoneStore.Controllers
{
    [Area("PhoneStore")]
    public class SupplierController : Controller
    {
        private readonly IMediator _mediator;

        public SupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> GetSuppliers()
        {
            var suppliers = await _mediator.Send(new GetListOfSuppliersRequest());
            return Json(new {data = suppliers});
        }
        public async Task<JsonResult> GetSupplier(int id)
        {
            var supplier = await _mediator.Send(new GetSupplierByIdRequest { Id = id });
            return Json(new { data = supplier });
        }
        public async Task<JsonResult> EditSupplier(SupplierDto supplierDto)
        {
            if (ModelState.IsValid)
            {
                var supplier = await _mediator.Send(new UpdateSupplierCommand { SupplierDto = supplierDto });
                return Json(new { data = supplier });
            }
            return Json(new { data = false });
        }
    }
}
