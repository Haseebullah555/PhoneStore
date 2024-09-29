using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.Goods.Request.Commands
{
    public class UpdateGoodCommand : IRequest<int>
    {
        public GoodsDto GoodsDto { get; set; }
    }
}
