using AutoMapper;
using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.ExtraExpenses.Request.Queries;

namespace PhoneStore.Application.Features.ExtraExpenses.Handler.Queries
{
    public class GetListOfExtraExpensesRequestHandler : IRequestHandler<GetListOfExtraExpensesRequest, List<ExtraExpensesDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetListOfExtraExpensesRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ExtraExpensesDto>> Handle(GetListOfExtraExpensesRequest request, CancellationToken cancellationToken)
        {
            var ExtraExpenses = await _unitOfWork.ExtraExpensesRepository.GetAll();
            return _mapper.Map<List<ExtraExpensesDto>>(ExtraExpenses);
        }
    }
}
