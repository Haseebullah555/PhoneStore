using AutoMapper;
using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.Goods.Request.Queries;

namespace PhoneStore.Application.Features.Goods.Handler.Queries
{
    public class GetListOfGoodsRequestHandler : IRequestHandler<GetListOfGoodsRequest, List<GoodsDto>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetListOfGoodsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<GoodsDto>> Handle(GetListOfGoodsRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.GoodsRepository.GetAllGoods();
        }
    }
}
