using PhoneStore.Application.Contracts;
using PhoneStore.Domain.Models;
using PhoneStore.Persistence.Database;
using PhoneStore.Persistence.Repositories.Common;

namespace PhoneStore.Persistence.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
