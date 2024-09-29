using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.Company.Request.Commands
{
    public class AddCompanyCommand : IRequest<int>
    {
        public CompanyDto CompanyDto { get; set; }
    }
}
