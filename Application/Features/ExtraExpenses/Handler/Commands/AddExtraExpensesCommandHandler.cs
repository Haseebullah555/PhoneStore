using AutoMapper;
using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Features.ExtraExpenses.Request.Commands;

namespace PhoneStore.Application.Features.ExtraExpenses.Handler.Commands
{
    public class AddExtraExpensesCommandHandler : IRequestHandler<AddExtraExpensesCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddExtraExpensesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Handle(AddExtraExpensesCommand request, CancellationToken cancellationToken)
        {
            var ExtraExpense = _mapper.Map<Domain.Models.ExtraExpenses>(request.ExtraExpensesDto);
            await _unitOfWork.ExtraExpensesRepository.Add(ExtraExpense);
            await _unitOfWork.SaveChanges(cancellationToken);
            return ExtraExpense.Id;
        }
    }
}
