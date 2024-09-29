using MediatR;
using PhoneStore.Domain.Models;

namespace PhoneStore.Application.Features.Additional.Request.Queries
{
    public class GetListOfProvincesRequest : IRequest<List<Province>>
    {
    }
}
