using AutoMapper;
using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Features.ExtraExpenses.Request.Commands;

namespace PhoneStore.Application.Features.ExtraExpenses.Handler.Commands
{
    public class UpdateExtraExpensesCommandHandler : IRequestHandler<UpdateExtraExpensesCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateExtraExpensesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Handle(UpdateExtraExpensesCommand request, CancellationToken cancellationToken)
        {
            var ExtraExpense = _mapper.Map<Domain.Models.ExtraExpenses>(request.ExtraExpensesDto);
            await _unitOfWork.ExtraExpensesRepository.Update(ExtraExpense);
            await _unitOfWork.SaveChanges(cancellationToken);
            return ExtraExpense.Id;
        }
    }
}
