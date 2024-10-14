using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.Purchase.Request.Queries;

namespace PhoneStore.Application.Features.Purchase.Handler.Queries
{
    public class GetPurchaseByIdRequestHandler : IRequestHandler<GetPurchaseByIdRequest, PurchaseDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPurchaseByIdRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PurchaseDto> Handle(GetPurchaseByIdRequest request, CancellationToken cancellationToken)
        {
            //   return await _unitOfWork.PurchaseRepository.GetPurchaseById(request.Id);
            return null;
        }
    }
}
