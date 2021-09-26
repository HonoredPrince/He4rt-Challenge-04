using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.DTOs.Trainer;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private ITrainerService _service;

        public TrainerController(ITrainerService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}", Name = "GetTrainerWithId")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.GetById(id);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TrainerCreateDTO trainer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Post(trainer);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetTrainerWithId", new { id = result.Id })), result);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
