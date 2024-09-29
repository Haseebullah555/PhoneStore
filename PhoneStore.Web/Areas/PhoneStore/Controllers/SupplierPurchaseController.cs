using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.Goods.Request.Queries;
using PhoneStore.Application.Features.Supplier.Request.Command;
using PhoneStore.Domain.Models;
using PhoneStore.Persistence.Database;

namespace PhoneStore.Web.Areas.PhoneStore.Controllers
{
    [Area("PhoneStore")]
    public class SupplierPurchaseController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;
        public SupplierPurchaseController(IMediator mediator,ApplicationDbContext dbContext)
        {
            _mediator = mediator;
            _context = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Goods = new SelectList(
                 (await _mediator.Send(new GetListOfGoodsRequest()))
                     .Select(g => new
                     {
                         g.Id,
                         DisplayText = g.GoodName + " - " + g.Company
                     }),
                 "Id",
                 "DisplayText"
             );
            Supplier supplier = new();
            supplier.Purchases.Add(new Purchase() { Id = 1 });
            return View(supplier);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SupplierDto supplierDto)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send( new AddSupplierCommand { SupplierDto = supplierDto });

                TempData["Message"] = "Supplier and purchases added successfully!";
                TempData["MessageType"] = "success";
                return RedirectToAction(nameof(Index), "Purchase");
            }

            return View(supplierDto);
        }
        
    }
}
