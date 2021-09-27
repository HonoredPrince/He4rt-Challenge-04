using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.DTOs.Pokemon;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private IPokemonService _service;

        public PokemonController(IPokemonService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Valida se o modelo do dado de input, caso não retorna um BadRequest(400)
            if (!ModelState.IsValid)
                return BadRequest(ModelState); //400
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetPokemonById")]
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

        [HttpGet]
        [Route("getByName/{pokemonName}", Name = "GetPokemonByName")]
        public async Task<IActionResult> GetByName(string pokemonName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.GetPokemonByName(pokemonName);
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
        public async Task<IActionResult> Post([FromBody] PokemonCreateDTO pokemonAdded)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Post(pokemonAdded);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetPokemonById", new { id = result.Id })), result);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
