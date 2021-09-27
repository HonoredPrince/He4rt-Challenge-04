using System;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Repository
{
    public interface ITrainerRepository : IRepository<TrainerEntity>
    {
        Task<TrainerEntity> AddPokemonToPokedex(Guid id, PokemonEntity pokemon);
    }
}
