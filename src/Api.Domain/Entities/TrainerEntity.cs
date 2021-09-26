using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class TrainerEntity : BaseEntity
    {
        [MaxLength(60)]
        public string Name { get; set; }
        public string Region { get; set; }
        public int Age { get; set; }
        public IEnumerable<PokemonEntity> Pokemons { get; set; }
    }
}
