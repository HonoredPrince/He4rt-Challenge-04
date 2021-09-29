using System;

namespace Api.Domain.DTOs.User
{
    public class UserCreateResultDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
