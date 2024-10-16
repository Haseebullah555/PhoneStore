﻿using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.Purchase.Request.Queries;

namespace PhoneStore.Application.Features.Purchase.Handler.Queries
{
    public class GetListOfSuppliersLoanRequestHandler : IRequestHandler<GetListOfSuppliersLoanRequest, List<PurchaseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetListOfSuppliersLoanRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<PurchaseDto>> Handle(GetListOfSuppliersLoanRequest request, CancellationToken cancellationToken)
        {
            // return await _unitOfWork.PurchaseRepository.GetSuppliersLoan();
            return null;
        }
    }
}
