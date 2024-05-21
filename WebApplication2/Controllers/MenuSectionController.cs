using AbaceriaLolo.Backend.Business.Services;
using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
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
        public async Task<IActionResult> CreateMenuSection([FromBody] MenuSectionDTO menuSection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _menuSectionService.CreateMenuSectionAsync(menuSection);
            return Ok(menuSection);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMenuSection(MenuSectionModel menuSection)
        {
            var menuSectionToUpdate = await _menuSectionService.GetMenuSectionByIdAsync(menuSection.MenuSectionId);

            if (menuSectionToUpdate == null)
            {
                return NotFound();
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _menuSectionService.UpdateMenuSectionAsync(menuSection);
            return Ok(await _menuSectionService.GetMenuSectionByIdAsync(menuSection.MenuSectionId));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuSection(int id)
        {
            var menuSectionToDelete = await _menuSectionService.GetMenuSectionByIdAsync(id);
            if (menuSectionToDelete == null)
            {
                return NotFound();
            }
            await _menuSectionService.DeleteMenuSectionAsync(id);
            return Ok(menuSectionToDelete);
        }
    }
}
