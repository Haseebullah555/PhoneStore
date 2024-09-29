using AutoMapper;
using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.Customer.Request.Queries;

namespace PhoneStore.Application.Features.Customer.Handler.Queries
{
    public class GetCustomerByIdRequestHandler : IRequestHandler<GetCustomerByIdRequest, CustomerDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCustomerByIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }
        public async Task<CustomerDto> Handle(GetCustomerByIdRequest request, CancellationToken cancellationToken)
        {
            var customer =  await _unitOfWork.CustomerReposistory.Get(request.Id);
            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
