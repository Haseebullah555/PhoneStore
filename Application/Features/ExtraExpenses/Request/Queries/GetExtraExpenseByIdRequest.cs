using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.ExtraExpenses.Request.Queries
{
    public class GetExtraExpenseByIdRequest : IRequest<ExtraExpensesDto>
    {
        public int Id { get; set; }
    }
}
