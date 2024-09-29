using PhoneStore.Application.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneStore.Application.Contracts;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PhoneStore.Persistence.Database;
namespace PhoneStore.Persistence.Repositories.Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> dbSet;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            dbSet = _dbContext.Set<T>();
        }
        public async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            return entity;

        }

        public async Task<List<T>> AddRanges(List<T> entity)
        {
            await _dbContext.AddRangeAsync(entity);
            return entity;
        }
        public async Task Update(T entity)
        {
            _dbContext.Update(entity);
        }
        public async Task Delete(T entity)
        {
            _dbContext.Remove(entity);
        }
        public IQueryable<T> All()
        {
            return _dbContext.Set<T>().AsQueryable();
        }



        public async Task<bool> Exists(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }

        public async Task<T> Get(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll1(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)// If requested records are based on a condation, then this block will execute.
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = true)
        {
            IQueryable<T> query;

            if (tracked)
            {
                query = dbSet;
            }
            else
            {
                query = dbSet.AsNoTracking();
            }

            query = query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            var result = await query.FirstOrDefaultAsync();
            if (result == null)
            {
                throw new ArgumentException($"No {typeof(T).Name}s found matching the filter. and this message comes form generic repository.");
            }

            return result;
        }

    }
}
