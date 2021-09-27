using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Domain.DTOs.Pokemon;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repository;
using Api.Domain.Interfaces.Services;
using Api.Domain.Models;
using AutoMapper;
using PokeApiNet;

namespace Api.Service.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _repository;
        private readonly IMapper _mapper;
        private readonly PokeApiClient _pokeApiClient;

        public PokemonService(IPokemonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _pokeApiClient = new PokeApiClient();
        }

        public async Task<IEnumerable<PokemonDTO>> GetAll()
        {
            var listEntity = await _repository.FindAllAsync();
            return _mapper.Map<IEnumerable<PokemonDTO>>(listEntity);
        }

        public async Task<PokemonDTO> GetById(Guid id)
        {
            return _mapper.Map<PokemonDTO>(await _repository.FindByIdAsync(id));
        }

        public async Task<PokemonPokeApiDTO> GetPokemonByName(string name)
        {
            var pokemon = await _pokeApiClient.GetResourceAsync<Pokemon>(name);
            return _mapper.Map<PokemonPokeApiDTO>(pokemon);
        }

        public async Task<PokemonCreateResultDTO> Post(PokemonCreateDTO pokemonAdded)
        {
            Pokemon pokemon;
            try
            {
                pokemon = await _pokeApiClient.GetResourceAsync<Pokemon>(pokemonAdded.Name);
            }
            catch (HttpRequestException)
            {
                throw;
            }
            var model = _mapper.Map<PokemonModel>(pokemonAdded);
            model.ImageUrl = pokemon.Sprites.FrontDefault;
            model.Attribute = pokemon.Types[0].Type.Name;
            var entity = _mapper.Map<PokemonEntity>(model);
            var result = await _repository.CreateAsync(entity);

            return _mapper.Map<PokemonCreateResultDTO>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
