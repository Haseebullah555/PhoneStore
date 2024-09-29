using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Features.Additional.Request.Queries;
using PhoneStore.Domain.Models;

namespace PhoneStore.Application.Features.Additional.Handler.Queries
{
    public class GetListOfProvincesRequesthandler : IRequestHandler<GetListOfProvincesRequest, List<Province>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetListOfProvincesRequesthandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Province>> Handle(GetListOfProvincesRequest request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ProvinceRepository.All().ToList();
        }
    }
}
