using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.Additional.Request.Queries;
using PhoneStore.Application.Features.Customer.Request.Commands;
using PhoneStore.Application.Features.Goods.Request.Queries;
using PhoneStore.Application.Features.Stock.Request.Query;
using PhoneStore.Domain.Models;
using PhoneStore.Persistence.Database;
namespace PhoneStore.Web.Areas.PhoneStore.Controllers
{
    [Area("PhoneStore")]
    public class CustomerSalesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;

        public CustomerSalesController(IMediator mediator,ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _mediator = mediator;
        }
        [HttpGet]   
        public async Task<IActionResult> Create()
        {
            ViewBag.Goods = new SelectList(
                 (await _mediator.Send(new GetListOfStockRequest()))
                     .Select(s => new
                     {
                         s.GoodId,
                         DisplayText = s.GoodName + " - " + s.CompanyName
                     }),
                 "GoodId",
                 "DisplayText"
             );
            ViewBag.Provinces = new SelectList(await _mediator.Send(new GetListOfProvincesRequest()),"Id","Name");
            Customer customer = new Customer();
            customer.Sales.Add(new Sales { Id = 1 });
            return View(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new AddCustomerCommand { CustomerDto = customerDto });
                TempData["AddCustomerMessage"] = "Customers and sales added successfully";
                TempData["MessageType"] = "success";
                return RedirectToAction(nameof(Index), "Sales");
            }
            return View(customerDto);
        }

    }
}
