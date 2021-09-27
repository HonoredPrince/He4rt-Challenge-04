using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _context;
        private DbSet<T> _dataset;

        public GenericRepository(MyContext context)
        {
            _context = context;
            _dataset = context.Set<T>();
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<T> FindByIdAsync(Guid id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<T> CreateAsync(T item)
        {
            try
            {
                if (item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }

                item.CreatedAt = DateTime.UtcNow;
                _dataset.Add(item);

                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                throw;
            }

            return item;
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));
                if (result == null)
                    return null;

                item.UpdatedAt = DateTime.UtcNow;
                item.CreatedAt = result.CreatedAt;

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                throw;
            }

            return item;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (result == null)
                    return false;

                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _dataset.AnyAsync(p => p.Id.Equals(id));
        }
    }
}
