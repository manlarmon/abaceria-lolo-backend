using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AbaceriaLolo.WebAPI.Controllers
{
    [ApiController]
    [Route("MenuSection")]
    public class MenuSectionController : ControllerBase
    {
        private readonly IMenuSectionService _menuSectionService;

        public MenuSectionController(IMenuSectionService menuSectionService)
        {
            _menuSectionService = menuSectionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenuSection()
        {
            var menuSections = await _menuSectionService.GetAllMenuSectionsAsync();
            return Ok(menuSections);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuSectionByIdAsync(int id)
        {
            var menuSection = await _menuSectionService.GetMenuSectionByIdAsync(id);
            if (menuSection == null)
            {
                return NotFound();
            }
            return Ok(menuSection);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenuSection([FromBody] MenuSectionModel menuSection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _menuSectionService.CreateMenuSectionAsync(menuSection);

            // Devuelve una respuesta HTTP 201 (Created) con la ubicación del recurso recién creado en el encabezado de la respuesta, y el objeto menuSection como el cuerpo de la respuesta.
            return CreatedAtAction(nameof(GetMenuSectionByIdAsync), new { id = menuSection.MenuSectionId }, menuSection);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenuSectionAsync(MenuSectionModel menuSection, int id)
        {
            var menuSectionToUpdate= await _menuSectionService.GetMenuSectionByIdAsync(id);
            if (menuSectionToUpdate == null)
            {
                return NotFound();
            }
            return Ok(_menuSectionService.UpdateMenuSectionAsync(menuSection, id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuSectionAsync(int id)
        {
            var menuSectionToDelete = await _menuSectionService.GetMenuSectionByIdAsync(id);
            if (menuSectionToDelete == null)
            {
                return NotFound();
            }
            return Ok(_menuSectionService.DeleteMenuSectionAsync(id));
        }
    }
}
