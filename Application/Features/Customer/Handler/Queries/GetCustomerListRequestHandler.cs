using AutoMapper;
using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.Customer.Request.Queries;

namespace PhoneStore.Application.Features.Customer.Handler.Queries
{
    public class GetCustomerListRequestHandler : IRequestHandler<GetCustomerListRequest, List<CustomerDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCustomerListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }
        public async Task<List<CustomerDto>> Handle(GetCustomerListRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CustomerReposistory.AllCustomers();
        }
    }
}
