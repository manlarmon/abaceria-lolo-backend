using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.WebAPI.Controllers
{
    [ApiController]
    [Route("AllergenMenuProduct")]
    public class AllergenMenuProductController : ControllerBase
    {
        private readonly IAllergenMenuProductService _allergenMenuProductService;

        public AllergenMenuProductController(IAllergenMenuProductService allergenMenuProductService)
        {
            _allergenMenuProductService = allergenMenuProductService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAllergenMenuProducts()
        {
            var allergenMenuProducts = await _allergenMenuProductService.GetAllAllergenMenuProductsAsync();
            return Ok(allergenMenuProducts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllergenMenuProductById(int id)
        {
            var allergenMenuProduct = await _allergenMenuProductService.GetAllergenMenuProductByIdAsync(id);
            if (allergenMenuProduct == null)
            {
                return NotFound();
            }
            return Ok(allergenMenuProduct);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAllergenMenuProduct([FromBody] AllergenMenuProductModel allergenMenuProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdAllergenMenuProduct = await _allergenMenuProductService.CreateAllergenMenuProductAsync(allergenMenuProduct);
            return CreatedAtAction(nameof(GetAllergenMenuProductById), new { id = createdAllergenMenuProduct.AllergenMenuProductId }, createdAllergenMenuProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAllergenMenuProduct(int id, [FromBody] AllergenMenuProductModel allergenMenuProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var allergenMenuProductToUpdate = await _allergenMenuProductService.GetAllergenMenuProductByIdAsync(id);
            if (allergenMenuProductToUpdate == null)
            {
                return NotFound();
            }

            allergenMenuProduct.AllergenMenuProductId = id;
            await _allergenMenuProductService.UpdateAllergenMenuProductAsync(allergenMenuProduct);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllergenMenuProduct(int id)
        {
            var allergenMenuProductToDelete = await _allergenMenuProductService.GetAllergenMenuProductByIdAsync(id);
            if (allergenMenuProductToDelete == null)
            {
                return NotFound();
            }

            await _allergenMenuProductService.DeleteAllergenMenuProductAsync(id);
            return NoContent();
        }
    }
}
