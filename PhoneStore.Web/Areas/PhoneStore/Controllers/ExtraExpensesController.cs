using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.ExtraExpenses.Request.Commands;
using PhoneStore.Application.Features.ExtraExpenses.Request.Queries;

namespace PhoneStore.Web.Areas.PhoneStore.Controllers
{
    [Area("PhoneStore")]
    public class ExtraExpensesController : Controller
    {
        private readonly IMediator _mediator;

        public ExtraExpensesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetExtraExpenses()
        {
            var ExtraExpenses = await _mediator.Send(new GetListOfExtraExpensesRequest());
            return Json(new { data = ExtraExpenses });
        }
        [HttpGet]
        public async Task<JsonResult> GetExtraExpense(int id)
        {
            var ExtraExpense = await _mediator.Send(new GetExtraExpenseByIdRequest { Id = id });
            return Json(new { data = ExtraExpense });
        }
        [HttpPost]
        public async Task<JsonResult> AddExtraExpense(ExtraExpensesDto extraExpensesDto)
        {
            if (ModelState.IsValid)
            {
                var ExtraExpense = await _mediator.Send(new AddExtraExpensesCommand { ExtraExpensesDto = extraExpensesDto });
                return Json(new { data = ExtraExpense });
            }
            return Json(new { data = false });
        }
         [HttpPost]
        public async Task<JsonResult> EditExtraExpense(ExtraExpensesDto extraExpensesDto)
        {
            if (ModelState.IsValid)
            {
                var ExtraExpense = await _mediator.Send(new UpdateExtraExpensesCommand { ExtraExpensesDto = extraExpensesDto });
                return Json(new { data = ExtraExpense });
            }
            return Json(new { data = false });
        }
        
    }
}
