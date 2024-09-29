using PhoneStore.Application.Contracts.Additional;
using PhoneStore.Domain.Models;
using PhoneStore.Persistence.Database;
using PhoneStore.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Persistence.Repositories.Additional
{
    public class ProvinceRepository : GenericRepository<Province>, IProvinceRepository 
    {
        public ProvinceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
