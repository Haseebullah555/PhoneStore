using PhoneStore.Application.Contracts;
using PhoneStore.Domain.Models;
using PhoneStore.Persistence.Database;
using PhoneStore.Persistence.Repositories.Common;

namespace PhoneStore.Persistence.Repositories
{
    class ExtraExpensesRepository : GenericRepository<ExtraExpenses>, IExtraExpensesRepository
    {
        public ExtraExpensesRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
