using AutoMapper;
using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Features.Goods.Request.Commands;

namespace PhoneStore.Application.Features.Goods.Handler.Commands
{
    public class UpdateGoodCommandHandler : IRequestHandler<UpdateGoodCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateGoodCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Handle(UpdateGoodCommand request, CancellationToken cancellationToken)
        {
            var Good = _mapper.Map<Domain.Models.Goods>(request.GoodsDto);
            await _unitOfWork.GoodsRepository.Update(Good);
            await _unitOfWork.SaveChanges(cancellationToken);
            return Good.Id;
        }
    }
}
