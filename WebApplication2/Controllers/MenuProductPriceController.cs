using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.WebAPI.Controllers
{
    [ApiController]
    [Route("MenuProductPrice")]
    public class MenuProductPriceController : ControllerBase
    {
        private readonly IMenuProductPriceService _menuProductPriceService;

        public MenuProductPriceController(IMenuProductPriceService menuProductPriceService)
        {
            _menuProductPriceService = menuProductPriceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenuProductPrices()
        {
            var menuProductPrices = await _menuProductPriceService.GetAllMenuProductPricesAsync();
            return Ok(menuProductPrices);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuProductPriceById(int id)
        {
            var menuProductPrice = await _menuProductPriceService.GetMenuProductPriceByIdAsync(id);
            if (menuProductPrice == null)
            {
                return NotFound();
            }
            return Ok(menuProductPrice);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenuProductPrice([FromBody] MenuProductPriceDTO menuProductPrice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdMenuProductPrice = await _menuProductPriceService.CreateMenuProductPriceAsync(menuProductPrice);
            return CreatedAtAction(nameof(GetMenuProductPriceById), new { id = createdMenuProductPrice.MenuProductPriceId }, createdMenuProductPrice);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenuProductPrice(int id, [FromBody] MenuProductPriceDTO menuProductPrice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingMenuProductPrice = await _menuProductPriceService.GetMenuProductPriceByIdAsync(id);
            if (existingMenuProductPrice == null)
            {
                return NotFound();
            }

            menuProductPrice.MenuProductPriceId = id;
            await _menuProductPriceService.UpdateMenuProductPriceAsync(menuProductPrice);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuProductPrice(int id)
        {
            var existingMenuProductPrice = await _menuProductPriceService.GetMenuProductPriceByIdAsync(id);
            if (existingMenuProductPrice == null)
            {
                return NotFound();
            }

            await _menuProductPriceService.DeleteMenuProductPriceAsync(id);
            return NoContent();
        }
    }
}
