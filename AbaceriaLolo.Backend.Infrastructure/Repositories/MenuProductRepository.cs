using AbaceriaLolo.Backend.Infrastructure.Data;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace AbaceriaLolo.Backend.Infrastructure.Repositories
{
    public class MenuProductRepository : IMenuProductRepository
    {
        private readonly DataContext _context;

        public MenuProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MenuProductModel>> GetAllMenuProductsAsync()
        {
            return await _context.MenuProduct.ToListAsync();
        }

        public async Task<MenuProductModel> GetMenuProductByIdAsync(int id)
        {
            return await _context.MenuProduct.FirstOrDefaultAsync(mp => mp.MenuProductId == id);
        }

        public async Task<MenuProductModel> CreateMenuProductAsync(MenuProductModel menuProduct)
        {
            await _context.MenuProduct.AddAsync(menuProduct);
            await _context.SaveChangesAsync();
            return menuProduct;
        }

        public async Task UpdateMenuProductAsync(MenuProductModel menuProduct)
        {
            var existingEntity = await _context.MenuProduct.FindAsync(menuProduct.MenuProductId);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(menuProduct);
                await _context.SaveChangesAsync();
            }
            else
            {
                // Opcional: Manejar el caso en que la entidad no existe
                throw new Exception("MenuProduct not found");
            }
        }

        public async Task DeleteMenuProductAsync(int id)
        {
            var menuProduct = await GetMenuProductByIdAsync(id);
            if (menuProduct != null)
            {
                _context.MenuProduct.Remove(menuProduct);
                await _context.SaveChangesAsync();
            }
        }
    }
}
