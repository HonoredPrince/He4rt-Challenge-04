using System.ComponentModel.DataAnnotations;

namespace Api.Domain.DTOs.User
{
    public class UserCreateDTO
    {
        [Required(ErrorMessage = "Email is a required field for adding a User")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is a required field for adding a User")]
        public string Password { get; set; }
    }
}
