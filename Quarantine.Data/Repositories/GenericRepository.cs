using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quarantine.Core.Models;
using Quarantine.Core.Repositories;
using Z.EntityFramework.Plus;

namespace Quarantine.Data.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly QuarantineDbContext _dbContext;
        private readonly DbSet<T> _set;

        protected GenericRepository(QuarantineDbContext dbContext)
        {
            _dbContext = dbContext;
            _set = dbContext.Set<T>();
        }

        public virtual async Task<ICollection<T>> GetAllAsync() => await _set.ToListAsync();

        public virtual async Task<T> GetAsync(Guid id) => await _set.FindAsync(id);

        public virtual async Task<T> AddAsync(T entity)
        {
            await _set.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _set.Attach(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<int> RemoveAsync(T entity)
        {
            await _set.Where(_ => _.Id == entity.Id).DeleteAsync();
            return await _dbContext.SaveChangesAsync();
        }
    }
}