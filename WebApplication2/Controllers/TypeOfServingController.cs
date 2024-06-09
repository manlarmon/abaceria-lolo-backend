using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.WebAPI.Controllers
{
    [ApiController]
    [Route("TypeOfServing")]
    public class TypeOfServingController : ControllerBase
    {
        private readonly ITypeOfServingService _typeOfServingService;

        public TypeOfServingController(ITypeOfServingService typeOfServingService)
        {
            _typeOfServingService = typeOfServingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTypesOfServing()
        {
            var typesOfServing = await _typeOfServingService.GetAllTypesOfServingAsync();
            return Ok(typesOfServing);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypeOfServingById(int id)
        {
            var typeOfServing = await _typeOfServingService.GetTypeOfServingByIdAsync(id);
            if (typeOfServing == null)
            {
                return NotFound();
            }
            return Ok(typeOfServing);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateTypeOfServing([FromBody] TypeOfServingDTO typeOfServing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdTypeOfServing = await _typeOfServingService.CreateTypeOfServingAsync(typeOfServing);
            return CreatedAtAction(nameof(GetTypeOfServingById), new { id = createdTypeOfServing.TypeOfServingId }, createdTypeOfServing);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateTypeOfServing(int id, [FromBody] TypeOfServingDTO typeOfServing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingTypeOfServing = await _typeOfServingService.GetTypeOfServingByIdAsync(id);
            if (existingTypeOfServing == null)
            {
                return NotFound();
            }

            typeOfServing.TypeOfServingId = id;
            await _typeOfServingService.UpdateTypeOfServingAsync(typeOfServing);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTypeOfServing(int id)
        {
            var existingTypeOfServing = await _typeOfServingService.GetTypeOfServingByIdAsync(id);
            if (existingTypeOfServing == null)
            {
                return NotFound();
            }

            await _typeOfServingService.DeleteTypeOfServingAsync(id);
            return NoContent();
        }
    }
}
