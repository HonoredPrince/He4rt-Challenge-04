using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.DTOs.Pokemon;
using Api.Domain.Interfaces.Repository;
using Api.Domain.Interfaces.Services;
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
            throw new NotImplementedException();
        }

        public async Task<PokemonDTO> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PokemonPokeApiDTO> GetPokemonByName(string name)
        {
            var pokemon = await _pokeApiClient.GetResourceAsync<Pokemon>(name);
            return _mapper.Map<PokemonPokeApiDTO>(pokemon);
        }

        public async Task<PokemonCreateResultDTO> Post(PokemonCreateDTO pokemon)
        {
            throw new NotImplementedException();
        }

        public async Task<PokemonUpdateResultDTO> Put(PokemonUpdateDTO pokemon)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
