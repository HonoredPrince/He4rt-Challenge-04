using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> FindByIdAsync(Guid id);
        Task<IEnumerable<T>> FindAllAsync();
        Task<T> CreateAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<T> UpdatePartialAsync(T item, params Expression<Func<T, object>>[] includeProperties);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
    }
}
