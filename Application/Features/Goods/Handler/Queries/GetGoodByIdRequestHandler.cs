using AutoMapper;
using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.Goods.Request.Queries;

namespace PhoneStore.Application.Features.Goods.Handler.Queries
{
    public class GetGoodByIdRequestHandler : IRequestHandler<GetGoodByIdRequest, GoodsDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGoodByIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GoodsDto> Handle(GetGoodByIdRequest request, CancellationToken cancellationToken)
        {
            var good = await _unitOfWork.GoodsRepository.Get(request.Id);
            return _mapper.Map<GoodsDto>(good);
        }
    }
}
