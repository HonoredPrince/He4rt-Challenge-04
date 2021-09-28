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
        Task<TrainerCompleteDTO> GetCompleteTrainerById(Guid id);
        Task<TrainerDTO> GetById(Guid id);
        Task<TrainerCreateResultDTO> Create(TrainerCreateDTO trainer);
        Task<TrainerCompleteDTO> AddPokemonToPokedex(Guid trainerId, PokemonAddDTO pokemon);
        Task<TrainerUpdateResultDTO> Update(TrainerUpdateDTO trainer);
        Task<bool> Delete(Guid id);
    }
}
