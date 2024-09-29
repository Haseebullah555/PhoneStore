using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.Goods.Request.Commands;
using PhoneStore.Application.Features.Goods.Request.Queries;

namespace PhoneStore.Web.Areas.PhoneStore.Controllers
{
    [Area("PhoneStore")]
    public class GoodsController : Controller
    {
        private readonly IMediator _mediator;

        public GoodsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Company = new SelectList(await _mediator.Send(new GetListOfCompanyRequest()), "Id", "CompanyName");
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetGoods()
        {
            var goods = await _mediator.Send(new GetListOfGoodsRequest());
            return Json(new { data = goods });
        }
        [HttpGet]
        public async Task<JsonResult> GetGood(int id)
        {
            var good = await _mediator.Send(new GetGoodByIdRequest { Id = id });
            return Json(new { data = good });
        }
        [HttpPost]
        public async Task<JsonResult> AddGood(GoodsDto goodsDto)
        {
            if (ModelState.IsValid)
            {
                var good = await _mediator.Send(new AddGoodCommand { GoodsDto = goodsDto });
                return Json(new { data = good });
            }
            return Json(new { data = false });
        }
        [HttpPost]
        public async Task<JsonResult> EditGood(GoodsDto goodsDto)
        {
            if (ModelState.IsValid)
            {
                var good = await _mediator.Send(new UpdateGoodCommand { GoodsDto = goodsDto });
                return Json(new { data = good });
            }
            return Json(new { data = false });
        }
    }
}
