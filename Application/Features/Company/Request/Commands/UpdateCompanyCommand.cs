using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.Company.Request.Commands
{
    public class UpdateCompanyCommand : IRequest<int>
    {
        public CompanyDto CompanyDto { get; set; }
    }
}
