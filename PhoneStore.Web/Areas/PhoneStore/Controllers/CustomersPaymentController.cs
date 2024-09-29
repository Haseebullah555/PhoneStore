using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.CustomerPayment.Request.Command;
using PhoneStore.Application.Features.CustomerPayment.Request.Query;
using PhoneStore.Web.Models;

namespace PhoneStore.Web.Areas.PhoneStore.Controllers
{
    [Area("PhoneStore")]
    public class CustomersPaymentController : Controller
    {
        private readonly IMediator _mediator;

        public CustomersPaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> GetCustomersPayment()
        {
            var payments = await _mediator.Send(new GetListOfCustomersPaymentRequest()); 
            return Json(new {data = payments});
        }
        public async Task<JsonResult> GetCustomerPayment(int id)
        {
            var payment = await _mediator.Send(new GetListOfCustomerPaymentsByCustomerIdRequest { Id = id });
            return Json(new {data = payment});
        }
        [HttpPost]
        public async Task<JsonResult> AddCustomerPayment(CustomerLoanPaymentViewModel customerLoanPaymentViewModel)
        {
            if (ModelState.IsValid)
            {
                // Send the command to the mediator
                var result = await _mediator.Send(new AddCustomerPaymentCommand { CustomerId = customerLoanPaymentViewModel.CustomersPaymentDto.Id, PaymentAmount = customerLoanPaymentViewModel.CustomersPaymentDto.PaymentAmount });

                // Return success response with result
                return Json(new { data = result });
            }
            // Return failure response if the model state is not valid
            return Json(new { data = false });
        }
    }
}
