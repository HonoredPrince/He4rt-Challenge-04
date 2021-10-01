using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.DTOs.Pokemon
{
    public class PokemonAddDTO
    {
        [Required(ErrorMessage = "Id is a required field for adding a Pokemon")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is a required field for adding a Pokemon")]
        public string Name { get; set; }
    }
}
