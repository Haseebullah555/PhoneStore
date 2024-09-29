using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.Goods.Request.Queries
{
    public class GetGoodByIdRequest : IRequest<GoodsDto>
    {
        public int Id { get; set; }
    }
}
