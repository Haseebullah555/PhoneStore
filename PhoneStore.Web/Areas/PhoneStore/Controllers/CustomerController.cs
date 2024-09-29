using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.Additional.Request.Queries;
using PhoneStore.Application.Features.Customer.Request.Commands;
using PhoneStore.Application.Features.Customer.Request.Queries;

namespace PhoneStore.Web.Areas.PhoneStore.Controllers
{
    [Area("PhoneStore")]
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Provinces = new SelectList(await _mediator.Send(new GetListOfProvincesRequest()),"Id","Name");
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetCustomers()
        {
            var Customers = await _mediator.Send(new GetCustomerListRequest());
            return Json(new {data = Customers });
        }
        public async Task<JsonResult> GetCustomer(int id)
        {
            var customer = await _mediator.Send(new GetCustomerByIdRequest { Id = id });
            return Json(new {data = customer });
        }
        [HttpPost]
        public async Task<JsonResult> AddCustomer(CustomerDto customerDto)
        {

            if (ModelState.IsValid)
            {
                var AddCustomer = await _mediator.Send(new AddCustomerCommand { CustomerDto = customerDto });
                return Json(new { data = AddCustomer });
            }
            return Json(new { data = false });
        }
        [HttpPost]
        public async Task<JsonResult> EditCustomer(CustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                var UpdateCustomer = await _mediator.Send(new UpdateCustomerCommand { CustomerDto = customerDto });
                return Json(new { data = UpdateCustomer });
            }
            return Json(new { data = false });
        }

    }
}
