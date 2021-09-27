using System;
using System.Collections.Generic;
using Api.Domain.DTOs.Pokemon;

namespace Api.Domain.DTOs.Trainer
{
    public class TrainerCompleteDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public int Age { get; set; }
        public List<PokemonDTO> Pokemons { get; set; }
    }
}
