using AutoMapper;
using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.ExtraExpenses.Request.Queries;

namespace PhoneStore.Application.Features.ExtraExpenses.Handler.Queries
{
    public class GetExtraExpenseByIdRequestHandler : IRequestHandler<GetExtraExpenseByIdRequest, ExtraExpensesDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetExtraExpenseByIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ExtraExpensesDto> Handle(GetExtraExpenseByIdRequest request, CancellationToken cancellationToken)
        {
            var ExtraExpense = await _unitOfWork.ExtraExpensesRepository.Get(request.Id);
            return _mapper.Map<ExtraExpensesDto>(ExtraExpense);
        }
    }
}
