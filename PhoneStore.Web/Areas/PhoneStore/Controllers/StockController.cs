using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneStore.Application.Features.Sale.Request.Queries;
using PhoneStore.Application.Features.Stock.Request.Query;

namespace PhoneStore.Web.Areas.PhoneStore.Controllers
{
    [Area("PhoneStore")]
    public class StockController : Controller
    {
        private readonly IMediator _mediator;

        public StockController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> AvailibleStock()
        {
            var stock = await _mediator.Send(new GetListOfStockRequest());
            return Json(new {data = stock});
        }

    }
}
