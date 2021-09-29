using System.Threading.Tasks;
using Api.Domain.DTOs.Token;
using Api.Domain.DTOs.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _service;

        public LoginController(ILoginService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> Signin([FromBody] UserLoginDTO user)
        {
            if (user == null) return BadRequest("Invalid client request");
            var token = await _service.ValidateCredentials(user);
            if (token == null) return Unauthorized();
            return Ok(token);
        }

        [HttpPost]
        [Route("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenDTO tokenDTO)
        {
            if (tokenDTO is null) return BadRequest("Invalid client request");
            var token = await _service.ValidateCredentials(tokenDTO);
            if (token == null) return BadRequest("Invalid client request");
            return Ok(token);
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("revoke")]
        public async Task<IActionResult> Revoke()
        {
            var username = User.Identity.Name;
            var result = await _service.RevokeToken(username);

            if (!result) return BadRequest("Invalid client request");
            return NoContent();
        }
    }
}
