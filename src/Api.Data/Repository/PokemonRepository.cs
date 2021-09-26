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
    }
}
