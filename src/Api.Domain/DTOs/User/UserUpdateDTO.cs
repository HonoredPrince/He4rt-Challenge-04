using System;

namespace Api.Domain.DTOs.User
{
    public class UserUpdateDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
