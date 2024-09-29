using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.Company.Request.Commands;
using PhoneStore.Application.Features.Company.Request.Queries;
using PhoneStore.Application.Features.Goods.Request.Queries;

namespace PhoneStore.Web.Areas.PhoneStore.Controllers
{
    [Area("PhoneStore")]
    public class CompanyController : Controller
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetCompanies()
        {
            var companies = await _mediator.Send(new GetListOfCompanyRequest());
            return Json(new {data =  companies});
        }
        [HttpGet]
        public async Task<JsonResult> GetCompany(int id)
        {
            var company = await _mediator.Send(new GetCompanyByIdRequest { Id = id });
            return Json(new {data = company});
        }
        [HttpPost]
        public async Task<JsonResult> AddCompany(CompanyDto companyDto)
        {
            if (ModelState.IsValid)
            {
                var company = await _mediator.Send(new AddCompanyCommand { CompanyDto = companyDto });
                return Json(new { data = company });
            }
            return Json(new {data = false});
        }
        [HttpPost]
        public async Task<JsonResult> EditCompany(CompanyDto companyDto)
        {
            if (ModelState.IsValid)
            {
                var company = await _mediator.Send(new UpdateCompanyCommand { CompanyDto = companyDto });
                return Json(new { data = company });
            }
            return Json(new { data = false });
        }
    }
}
