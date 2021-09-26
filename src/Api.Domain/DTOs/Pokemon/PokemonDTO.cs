using System;

namespace Api.Domain.DTOs.Pokemon
{
    public class PokemonDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Attribute { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
