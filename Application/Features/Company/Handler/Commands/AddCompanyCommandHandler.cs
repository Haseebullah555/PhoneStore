using AutoMapper;
using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Features.Company.Request.Commands;

namespace PhoneStore.Application.Features.Company.Handler.Commands
{
    public class AddCompanyCommandHandler : IRequestHandler<AddCompanyCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddCompanyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = _mapper.Map<Domain.Models.Company>(request.CompanyDto);
            await _unitOfWork.CompanyRepository.Add(company);
            await _unitOfWork.SaveChanges(cancellationToken);
            return company.Id;
        }
    }
}
