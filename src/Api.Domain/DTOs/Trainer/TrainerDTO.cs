using System;

namespace Api.Domain.DTOs.Trainer
{
    public class TrainerDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public int Age { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
