using PhoneStore.Application.Contracts.Common;
using PhoneStore.Application.Dtos;
using PhoneStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Application.Contracts
{
    public interface IGoodsRepository : IGenericRepository<Goods>
    {
        Task<List<GoodsDto>> GetAllGoods();
    }
}
