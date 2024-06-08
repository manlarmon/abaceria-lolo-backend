using Microsoft.AspNetCore.Mvc;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using System.Threading.Tasks;
using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace AbaceriaLolo.WebAPI.Controllers
{
    [ApiController]
    [Route("MenuSection")]
    public class MenuSectionController : ControllerBase
    {
        private readonly IMenuSectionService _menuSectionService;
        private readonly IMenuProductPriceService _menuProductPriceService; // Añadido

        public MenuSectionController(IMenuSectionService menuSectionService, IMenuProductPriceService menuProductPriceService)
        {
            _menuSectionService = menuSectionService;
            _menuProductPriceService = menuProductPriceService; // Añadido
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenuSections()
        {
            var menuSections = await _menuSectionService.GetAllMenuSectionsAsync();
            return Ok(menuSections);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuSectionById(int id)
        {
            var menuSection = await _menuSectionService.GetMenuSectionByIdAsync(id);
            if (menuSection == null)
            {
                return NotFound();
            }
            return Ok(menuSection);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateMenuSection([FromBody] MenuSectionDTO menuSection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _menuSectionService.CreateMenuSectionAsync(menuSection);
            return Ok(menuSection);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateMenuSection(int id, [FromBody] MenuSectionDTO menuSection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var menuSectionToUpdate = await _menuSectionService.GetMenuSectionByIdAsync(id);
            if (menuSectionToUpdate == null)
            {
                return NotFound();
            }

            menuSection.MenuSectionId = id;
            await _menuSectionService.UpdateMenuSectionAsync(menuSection);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteMenuSection(int id)
        {
            var menuSectionToDelete = await _menuSectionService.GetMenuSectionByIdAsync(id);
            if (menuSectionToDelete == null)
            {
                return NotFound();
            }

            await _menuSectionService.DeleteMenuSectionAsync(id);
            return NoContent();
        }

        // Nuevo endpoint para ajuste de precios
        [HttpPost("{id}/adjust-prices")]
        [Authorize]
        public async Task<IActionResult> AdjustPricesForSection(int id, [FromBody] decimal adjustment)
        {
            try
            {
                await _menuProductPriceService.AdjustPricesForSectionAsync(id, adjustment);
                return Ok();
            }
            catch
            {
                return StatusCode(500, "Error adjusting prices for section");
            }
        }
    }
}
