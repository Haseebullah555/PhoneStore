using AutoMapper;
using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Features.Sale.Request.Commands;

namespace PhoneStore.Application.Features.Sale.Handler.Commands
{
    public class UpdateSaleCommandHandler : IRequestHandler<UpdateSaleCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSaleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = _mapper.Map<Domain.Models.Sales>(request.SalesDto);
            //await _unitOfWork.SalesRepository.Update(sale);
            await _unitOfWork.SaveChanges(cancellationToken);
            return sale.Id;
        }
    }
}
