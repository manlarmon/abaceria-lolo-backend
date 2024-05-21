using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
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

            await _allergenService.CreateAllergenAsync(allergen);

            // Devuelve una respuesta HTTP 201 (Created) con la ubicación del recurso recién creado en el encabezado de la respuesta, y el objeto allergen como el cuerpo de la respuesta.
            var allergens = await _allergenService.GetAllAllergensAsync();
            var lastAllergen = allergens.Last();
            return Ok(lastAllergen);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAllergenAsync(AllergenModel allergen)
        {
            var allergenToUpdate = await _allergenService.GetAllergenByIdAsync(allergen.AllergenId);

            if (allergenToUpdate == null)
            {
                return NotFound();
            }
            else if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _allergenService.UpdateAllergenAsync(allergen);
            return Ok(await _allergenService.GetAllergenByIdAsync(allergen.AllergenId));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllergen(int id)
        {
            var allergenToDelete = await _allergenService.GetAllergenByIdAsync(id);
            if (allergenToDelete == null)
            {
                return NotFound();
            }
            await _allergenService.DeleteAllergenAsync(id);
            return Ok(allergenToDelete);
        }
    }
}
