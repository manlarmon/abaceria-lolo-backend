using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.WebAPI.Controllers
{
    [ApiController]
    [Route("Allergen")]
    public class AllergenController : ControllerBase
    {
        private readonly IAllergenService _allergenService;

        public AllergenController(IAllergenService allergenService)
        {
            _allergenService = allergenService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAllergens()
        {
            var allergens = await _allergenService.GetAllAllergensAsync();
            return Ok(allergens);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllergenById(int id)
        {
            var allergen = await _allergenService.GetAllergenByIdAsync(id);
            if (allergen == null)
            {
                return NotFound();
            }
            return Ok(allergen);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAllergen([FromBody] AllergenDTO allergen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdAllergen = await _allergenService.CreateAllergenAsync(allergen);
            return CreatedAtAction(nameof(GetAllergenById), new { id = createdAllergen.AllergenId }, createdAllergen);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAllergen(int id, [FromBody] AllergenDTO allergen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingAllergen = await _allergenService.GetAllergenByIdAsync(id);
            if (existingAllergen == null)
            {
                return NotFound();
            }

            allergen.AllergenId = id;
            await _allergenService.UpdateAllergenAsync(allergen);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllergen(int id)
        {
            var existingAllergen = await _allergenService.GetAllergenByIdAsync(id);
            if (existingAllergen == null)
            {
                return NotFound();
            }

            await _allergenService.DeleteAllergenAsync(id);
            return NoContent();
        }
    }
}
