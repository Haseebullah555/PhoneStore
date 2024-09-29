using AutoMapper;
using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Features.Company.Request.Commands;

namespace PhoneStore.Application.Features.Company.Handler.Commands
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCompanyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
           var company = _mapper.Map<Domain.Models.Company>(request.CompanyDto);
            await _unitOfWork.CompanyRepository.Update(company);
            await _unitOfWork.SaveChanges(cancellationToken);
            return company.Id;
        }
    }
}
