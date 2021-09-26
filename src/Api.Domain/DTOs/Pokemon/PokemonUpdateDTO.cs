using System;

namespace Api.Domain.DTOs.Pokemon
{
    public class PokemonUpdateDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Attribute { get; set; }
    }
}
