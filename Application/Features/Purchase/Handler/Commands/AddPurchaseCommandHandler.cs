using AutoMapper;
using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Features.Purchase.Request.Commands;

namespace PhoneStore.Application.Features.Purchase.Handler.Commands
{
    public class AddPurchaseCommandHandler : IRequestHandler<AddPurchaseCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddPurchaseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Handle(AddPurchaseCommand request, CancellationToken cancellationToken)
        {
            var purchase = _mapper.Map<Domain.Models.Purchase>(request.PurchaseDto);
           // await _unitOfWork.PurchaseRepository.Add(purchase);
            await _unitOfWork.SaveChanges(cancellationToken);
            return purchase.Id;

        }
    }
}
