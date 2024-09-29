using AutoMapper;
using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Features.Supplier.Request.Command;

namespace PhoneStore.Application.Features.Supplier.Handler.Command
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSupplierCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }
        public async Task<int> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = _mapper.Map<Domain.Models.Supplier>(request.SupplierDto);
            await _unitOfWork.SupplierRepository.Update(supplier);
            await _unitOfWork.SaveChanges(cancellationToken);
            return supplier.Id;
        }
    }
}
