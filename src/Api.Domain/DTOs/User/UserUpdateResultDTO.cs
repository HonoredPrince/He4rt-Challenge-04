using System;

namespace Api.Domain.DTOs.User
{
    public class UserUpdateResultDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
