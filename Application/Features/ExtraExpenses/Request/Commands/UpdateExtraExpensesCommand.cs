using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.ExtraExpenses.Request.Commands
{
    public class UpdateExtraExpensesCommand : IRequest<int>
    {
        public ExtraExpensesDto ExtraExpensesDto { get; set; }
    }
}
