using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AbaceriaLolo.Backend.WebApi.Controllers
{
    [ApiController]
    [Route("MenuProduct")]
    public class MenuProductController : ControllerBase
    {
        private readonly IMenuProductService _menuProductService;

        public MenuProductController(IMenuProductService menuProductService)
        {
            _menuProductService = menuProductService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenuProducts()
        {
            var menuProducts = await _menuProductService.GetAllMenuProductsAsync();
            return Ok(menuProducts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuProductById(int id)
        {
            var menuProduct = await _menuProductService.GetMenuProductByIdAsync(id);
            if (menuProduct == null)
            {
                return NotFound();
            }
            return Ok(menuProduct);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenuProduct([FromBody] MenuProductDTO menuProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            // Devuelve una respuesta HTTP 201 (Created) con la ubicación del recurso recién creado en el encabezado de la respuesta, y el objeto menuProduct como el cuerpo de la respuesta.
            var createdProduct = await _menuProductService.CreateMenuProductAsync(menuProduct);
            return CreatedAtAction(nameof(GetMenuProductById), new { id = createdProduct.MenuProductId }, createdProduct);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMenuProductAsync(MenuProductModel menuProduct)
        {
            var menuProductToUpdate = await _menuProductService.GetMenuProductByIdAsync(menuProduct.MenuProductId);

            if (menuProductToUpdate == null)
            {
                return NotFound();
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _menuProductService.UpdateMenuProductAsync(menuProduct);
            return Ok(await _menuProductService.GetMenuProductByIdAsync(menuProduct.MenuProductId));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuProduct(int id)
        {
            var menuProductToDelete = await _menuProductService.GetMenuProductByIdAsync(id);
            if (menuProductToDelete == null)
            {
                return NotFound();
            }
            await _menuProductService.DeleteMenuProductAsync(id);
            return Ok(menuProductToDelete);
        }
    }
}