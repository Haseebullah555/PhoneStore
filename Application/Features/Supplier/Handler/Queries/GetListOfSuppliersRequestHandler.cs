using AutoMapper;
using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.Supplier.Request.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Application.Features.Supplier.Handler.Queries
{
    public class GetListOfSuppliersRequestHandler : IRequestHandler<GetListOfSuppliersRequest, List<SupplierDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetListOfSuppliersRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<SupplierDto>> Handle(GetListOfSuppliersRequest request, CancellationToken cancellationToken)
        {
            var Suppliers = _unitOfWork.SupplierRepository.All().ToList();
            return _mapper.Map<List<SupplierDto>>(Suppliers);
        }
    }
}
