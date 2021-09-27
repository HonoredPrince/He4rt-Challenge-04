using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class PokemonRepository : GenericRepository<PokemonEntity>, IPokemonRepository
    {
        private readonly DbSet<PokemonEntity> _dataset;

        public PokemonRepository(MyContext context) : base(context)
        {
            _dataset = context.Set<PokemonEntity>();
        }

        public async Task<PokemonEntity> FindCompleteById(Guid id)
        {
            try
            {
                return await _dataset.Include(p => p.Trainers)
                                     .FirstOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
