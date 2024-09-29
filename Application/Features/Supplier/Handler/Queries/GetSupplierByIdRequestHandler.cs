using AutoMapper;
using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.Supplier.Request.Queries;

namespace PhoneStore.Application.Features.Supplier.Handler.Queries
{
    public class GetSupplierByIdRequestHandler : IRequestHandler<GetSupplierByIdRequest, SupplierDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSupplierByIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<SupplierDto> Handle(GetSupplierByIdRequest request, CancellationToken cancellationToken)
        {
            var supplier = await _unitOfWork.SupplierRepository.Get(request.Id);
            return _mapper.Map<SupplierDto>(supplier);
        }
    }
}
