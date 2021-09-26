using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.DTOs.Pokemon;

namespace Api.Domain.Interfaces.Services
{
    public interface IPokemonService
    {
        Task<IEnumerable<PokemonDTO>> GetAll();
        Task<PokemonDTO> GetById(Guid id);
        Task<PokemonPokeApiDTO> GetPokemonByName(string name);
        Task<PokemonCreateResultDTO> Post(PokemonCreateDTO pokemon);
        Task<PokemonUpdateResultDTO> Put(PokemonUpdateDTO pokemon);
        Task<bool> Delete(Guid id);
    }
}
