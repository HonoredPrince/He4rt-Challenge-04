using System;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Repository
{
    public interface IPokemonRepository : IRepository<PokemonEntity>
    {
        Task<PokemonEntity> FindCompleteById(Guid id);
    }
}
