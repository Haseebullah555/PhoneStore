using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Application.Contracts.Common
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);
        //Typically retrieves all entities from the data store and returns them in a single collection uses eager loading
        Task<IReadOnlyList<T>> GetAll();

        IQueryable<T> All();

        Task<bool> Exists(int id);

        Task<T> Add(T entity);

        Task<List<T>> AddRanges(List<T> entity);

        Task Update(T entity);

        Task Delete(T entity);

        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = true);

        Task<IEnumerable<T>> GetAll1(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
    }
}
