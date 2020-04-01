using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quarantine.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<int> RemoveAsync(T entity);
    }
}
