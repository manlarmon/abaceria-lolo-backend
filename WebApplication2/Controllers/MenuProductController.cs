using Microsoft.AspNetCore.Mvc;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using System.Threading.Tasks;
using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace AbaceriaLolo.WebAPI.Controllers
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
        [Authorize]
        public async Task<IActionResult> CreateMenuProduct([FromBody] MenuProductDTO menuProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _menuProductService.CreateMenuProductAsync(menuProduct);
            return Ok(menuProduct);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateMenuProduct(int id, [FromBody] MenuProductDTO menuProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var menuProductToUpdate = await _menuProductService.GetMenuProductByIdAsync(id);
            if (menuProductToUpdate == null)
            {
                return NotFound();
            }

            menuProduct.MenuProductId = id;
            await _menuProductService.UpdateMenuProductAsync(menuProduct);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteMenuProduct(int id)
        {
            var menuProductToDelete = await _menuProductService.GetMenuProductByIdAsync(id);
            if (menuProductToDelete == null)
            {
                return NotFound();
            }

            await _menuProductService.DeleteMenuProductAsync(id);
            return NoContent();
        }
    }
}
