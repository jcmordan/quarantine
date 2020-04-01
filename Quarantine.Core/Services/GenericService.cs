using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Quarantine.Core.Repositories;

namespace Quarantine.Core.Services
{
    public abstract class GenericService<T> where T: class
    {
        private readonly IGenericRepository<T> _repository;

        protected GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<ICollection<T>> GetAllAsync() => await _repository.GetAllAsync();

        public virtual async Task<T> GetAsync(Guid id) => await _repository.GetAsync(id);
        
        public virtual async Task<T> AddAsync(T entity) => await _repository.AddAsync(entity);
        
        public virtual async Task<T> UpdateAsync(T entity) => await _repository.UpdateAsync(entity);
        
        public virtual async Task<int> RemoveAsync(T entity) => await _repository.RemoveAsync((entity));
    }
}
