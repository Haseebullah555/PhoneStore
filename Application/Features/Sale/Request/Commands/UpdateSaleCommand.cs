using MediatR;
using PhoneStore.Application.Dtos;

namespace PhoneStore.Application.Features.Sale.Request.Commands
{
    public class UpdateSaleCommand : IRequest<int>
    {
        public SalesDto SalesDto { get; set; }
    }
}
