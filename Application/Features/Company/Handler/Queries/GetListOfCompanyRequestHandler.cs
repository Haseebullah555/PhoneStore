using AutoMapper;
using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.Goods.Request.Queries;

namespace PhoneStore.Application.Features.Company.Handler.Queries
{
    public class GetListOfCompanyRequestHandler : IRequestHandler<GetListOfCompanyRequest, List<CompanyDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetListOfCompanyRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<CompanyDto>> Handle(GetListOfCompanyRequest request, CancellationToken cancellationToken)
        {
            var company = _unitOfWork.CompanyRepository.All().ToList();
            return _mapper.Map<List<CompanyDto>>(company);
        }
    }
}
