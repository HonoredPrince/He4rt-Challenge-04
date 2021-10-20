using System;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Repository
{
    public interface ITrainerRepository : IRepository<TrainerEntity>
    {
        Task<TrainerEntity> FindCompleteById(Guid id);
        Task<TrainerEntity> FindCompleteByUserId(Guid userId);
        Task<TrainerEntity> AddPokemonToPokedex(Guid id, PokemonEntity pokemon);
        Task<bool> RemovePokemonFromPokedex(Guid trainerId, Guid pokemonId);
    }
}
