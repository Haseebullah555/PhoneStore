using AutoMapper;
using MediatR;
using PhoneStore.Application.Contracts;
using PhoneStore.Application.Features.Goods.Request.Commands;

namespace PhoneStore.Application.Features.Goods.Handler.Commands
{
    public class AddGoodCommandHandler : IRequestHandler<AddGoodCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddGoodCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Handle(AddGoodCommand request, CancellationToken cancellationToken)
        {
            var Good = _mapper.Map<Domain.Models.Goods>(request.GoodsDto);
            await _unitOfWork.GoodsRepository.Add(Good);
            await _unitOfWork.SaveChanges(cancellationToken);
            return Good.Id;
        }
    }
}
