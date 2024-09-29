using AutoMapper;
using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Features.Customer.Request.Commands;

namespace PhoneStore.Application.Features.Customer.Handler.Commands
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, int>
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfwork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Domain.Models.Customer>(request.CustomerDto);
            await _unitOfwork.CustomerReposistory.Update(customer);
            await _unitOfwork.SaveChanges(cancellationToken);
            return customer.Id;
        }
    }
}
