using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.DTOs.Pokemon;
using Api.Domain.DTOs.Trainer;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services
{
    public interface ITrainerService
    {
        Task<IEnumerable<TrainerDTO>> GetAll();
        Task<TrainerDTO> GetById(Guid id);
        Task<TrainerCreateResultDTO> Post(TrainerCreateDTO trainer);
        Task<TrainerCompleteDTO> AddPokemonToPokedex(Guid trainerId, PokemonAddDTO pokemon);
        Task<TrainerUpdateResultDTO> Put(TrainerUpdateDTO trainer);
        Task<bool> Delete(Guid id);
    }
}
