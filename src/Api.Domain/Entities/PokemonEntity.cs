using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class PokemonEntity : BaseEntity
    {
        [MaxLength(60)]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Attribute { get; set; }
        public IEnumerable<TrainerEntity> Trainers { get; set; }
    }
}
