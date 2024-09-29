using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.Sale.Request.Queries
{
    public class GetSaleByIdRequest : IRequest<SalesDto>
    {
        public int SaleId { get; set; }
    }
}
