using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.WebAPI.Controllers
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
        public async Task<IActionResult> UpdateTypeOfServing(int id, [FromBody] TypeOfServingModel typeOfServing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var typeOfServingToUpdate = await _typeOfServingService.GetTypeOfServingByIdAsync(id);
            if (typeOfServingToUpdate == null)
            {
                return NotFound();
            }

            typeOfServing.TypeOfServingId = id;
            await _typeOfServingService.UpdateTypeOfServingAsync(typeOfServing);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeOfServing(int id)
        {
            var typeOfServingToDelete = await _typeOfServingService.GetTypeOfServingByIdAsync(id);
            if (typeOfServingToDelete == null)
            {
                return NotFound();
            }

            await _typeOfServingService.DeleteTypeOfServingAsync(id);
            return NoContent();
        }
    }
}
