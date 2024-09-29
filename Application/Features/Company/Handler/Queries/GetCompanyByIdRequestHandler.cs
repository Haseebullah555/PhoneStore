using AutoMapper;
using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.Company.Request.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Application.Features.Company.Handler.Queries
{
    public class GetCompanyByIdRequestHandler : IRequestHandler<GetCompanyByIdRequest, CompanyDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCompanyByIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }
        public async Task<CompanyDto> Handle(GetCompanyByIdRequest request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.CompanyRepository.Get(request.Id);
            return _mapper.Map<CompanyDto>(company);
        }
    }
}
