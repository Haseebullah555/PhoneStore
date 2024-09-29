using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.Goods.Request.Queries
{
    public class GetListOfGoodsRequest : IRequest<List<GoodsDto>>
    {
    }
}
