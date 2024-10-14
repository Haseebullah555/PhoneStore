using AutoMapper;
using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Features.Purchase.Request.Commands;

namespace PhoneStore.Application.Features.Purchase.Handler.Commands
{
    public class UpdatePurchaseCommandHandler : IRequestHandler<UpdatePurchaseCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePurchaseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Handle(UpdatePurchaseCommand request, CancellationToken cancellationToken)
        {
            var purchase = _mapper.Map<Domain.Models.Purchase>(request.PurchaseDto);
           // await _unitOfWork.PurchaseRepository.Update(purchase);
            await _unitOfWork.SaveChanges(cancellationToken);
            return purchase.Id;
        }
    }
}
