using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.WebAPI.Controllers
{
    [ApiController]
    [Route("InventorySection")]

    public class InventorySectionController : ControllerBase
    {
        private readonly IInventorySectionService _inventorySectionService;

        public InventorySectionController(IInventorySectionService inventorySectionService)
        {
            _inventorySectionService = inventorySectionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInventorySections()
        {
            var sections = await _inventorySectionService.GetAllInventorySectionsAsync();
            return Ok(sections);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventorySectionById(int id)
        {
            var section = await _inventorySectionService.GetInventorySectionByIdAsync(id);
            if (section == null)
            {
                return NotFound();
            }
            return Ok(section);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInventorySection([FromBody] InventorySectionDTO section)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdSection = await _inventorySectionService.CreateInventorySectionAsync(section);
            return CreatedAtAction(nameof(GetInventorySectionById), new { id = createdSection.InventorySectionId }, createdSection);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInventorySection(int id, [FromBody] InventorySectionDTO section)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingSection = await _inventorySectionService.GetInventorySectionByIdAsync(id);
            if (existingSection == null)
            {
                return NotFound();
            }

            section.InventorySectionId = id;
            await _inventorySectionService.UpdateInventorySectionAsync(section);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventorySection(int id)
        {
            var existingSection = await _inventorySectionService.GetInventorySectionByIdAsync(id);
            if (existingSection == null)
            {
                return NotFound();
            }

            await _inventorySectionService.DeleteInventorySectionAsync(id);
            return NoContent();
        }
    }
}
