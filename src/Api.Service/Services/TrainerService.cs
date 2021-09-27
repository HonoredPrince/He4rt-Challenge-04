using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.DTOs.Pokemon;
using Api.Domain.DTOs.Trainer;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repository;
using Api.Domain.Interfaces.Services;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _repository;
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public TrainerService(ITrainerRepository repository, IPokemonRepository pokemonRepository, IMapper mapper)
        {
            _repository = repository;
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TrainerDTO>> GetAll()
        {
            var listEntity = await _repository.FindAllAsync();
            return _mapper.Map<IEnumerable<TrainerDTO>>(listEntity);
        }

        public async Task<TrainerDTO> GetById(Guid id)
        {
            return _mapper.Map<TrainerDTO>(await _repository.FindByIdAsync(id));
        }

        public async Task<TrainerCreateResultDTO> Post(TrainerCreateDTO trainerCreated)
        {
            var model = _mapper.Map<TrainerModel>(trainerCreated);
            var entity = _mapper.Map<TrainerEntity>(model);
            var result = await _repository.CreateAsync(entity);

            return _mapper.Map<TrainerCreateResultDTO>(result);
        }

        public async Task<TrainerUpdateResultDTO> Put(TrainerUpdateDTO trainerUpdated)
        {
            var model = _mapper.Map<TrainerModel>(trainerUpdated);
            var entity = _mapper.Map<TrainerEntity>(model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<TrainerUpdateResultDTO>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<TrainerCompleteDTO> AddPokemonToPokedex(Guid trainerId, PokemonAddDTO pokemon)
        {
            if (!await _pokemonRepository.ExistsAsync(pokemon.Id) || !await _repository.ExistsAsync(trainerId))
            {
                return null;
            }
            var pokemonEntity = await _pokemonRepository.FindCompleteById(pokemon.Id);

            return _mapper.Map<TrainerCompleteDTO>(await _repository.AddPokemonToPokedex(trainerId, pokemonEntity));
        }
    }
}
