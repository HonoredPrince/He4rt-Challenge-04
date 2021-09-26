using System.ComponentModel.DataAnnotations;

namespace Api.Domain.DTOs.Trainer
{
    public class TrainerCreateDTO
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Region é um campo obrigatório")]
        public string Region { get; set; }
        [Required(ErrorMessage = "Age é um campo obrigatório")]
        public int Age { get; set; }
    }
}
