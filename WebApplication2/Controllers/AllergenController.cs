using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAllergenByIdAsync(int id)
        {
            var allergen = await _allergenService.GetAllergenByIdAsync(id);
            if (allergen == null)
            {
                return NotFound();
            }
            return Ok(allergen);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAllergen([FromBody] AllergenModel allergen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _allergenService.CreateAllergenAsync(allergen);

            // Devuelve una respuesta HTTP 201 (Created) con la ubicación del recurso recién creado en el encabezado de la respuesta, y el objeto allergen como el cuerpo de la respuesta.
            return CreatedAtAction(nameof(GetAllergenByIdAsync), new { id = allergen.AllergenId }, allergen);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAllergenAsync(AllergenModel allergen, int id)
        {
            var allergenToUpdate = await _allergenService.GetAllergenByIdAsync(id);
            if (allergenToUpdate == null)
            {
                return NotFound();
            }
            return Ok(_allergenService.UpdateAllergenAsync(allergen, id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllergenAsync(int id)
        {
            var allergenToDelete = await _allergenService.GetAllergenByIdAsync(id);
            if (allergenToDelete == null)
            {
                return NotFound();
            }
            return Ok(_allergenService.DeleteAllergenAsync(id));
        }
    }
}
