using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.WebAPI.Controllers
{
    [ApiController]
    [Route("InventoryProduct")]
    public class InventoryProductController : ControllerBase
    {
        private readonly IInventoryProductService _inventoryProductService;

        public InventoryProductController(IInventoryProductService inventoryProductService)
        {
            _inventoryProductService = inventoryProductService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInventoryProducts()
        {
            var products = await _inventoryProductService.GetAllInventoryProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventoryProductById(int id)
        {
            var product = await _inventoryProductService.GetInventoryProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInventoryProduct([FromBody] InventoryProductDTO product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdProduct = await _inventoryProductService.CreateInventoryProductAsync(product);
            return CreatedAtAction(nameof(GetInventoryProductById), new { id = createdProduct.InventoryProductId }, createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInventoryProduct(int id, [FromBody] InventoryProductDTO product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingProduct = await _inventoryProductService.GetInventoryProductByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            product.InventoryProductId = id;
            await _inventoryProductService.UpdateInventoryProductAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryProduct(int id)
        {
            var existingProduct = await _inventoryProductService.GetInventoryProductByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            await _inventoryProductService.DeleteInventoryProductAsync(id);
            return NoContent();
        }
    }
}
