using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.ExtraExpenses.Request.Queries
{
    public class GetListOfExtraExpensesRequest : IRequest<List<ExtraExpensesDto>>
    {
    }
}
