using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.Company.Request.Queries
{
    public class GetCompanyByIdRequest : IRequest<CompanyDto>
    {
        public int Id { get; set; }
    }
}
