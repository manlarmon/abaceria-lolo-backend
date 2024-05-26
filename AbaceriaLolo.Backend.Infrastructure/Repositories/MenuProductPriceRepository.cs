using AbaceriaLolo.Backend.Infrastructure.Data;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Repositories
{
    public class MenuProductPriceRepository : IMenuProductPriceRepository
    {
        private readonly DataContext _context;

        public MenuProductPriceRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MenuProductPriceModel>> GetAllMenuProductPricesAsync()
        {
            return await _context.MenuProductPrice
                .Include(mpp => mpp.TypeOfServing) // Include related entities if needed
                .ToListAsync();
        }

        public async Task<MenuProductPriceModel> GetMenuProductPriceByIdAsync(int id)
        {
            return await _context.MenuProductPrice
                .Include(mpp => mpp.TypeOfServing) // Include related entities if needed
                .FirstOrDefaultAsync(mpp => mpp.MenuProductPriceId == id);
        }

        public async Task<MenuProductPriceModel> CreateMenuProductPriceAsync(MenuProductPriceModel menuProductPrice)
        {
            await _context.MenuProductPrice.AddAsync(menuProductPrice);
            await _context.SaveChangesAsync();
            return menuProductPrice;
        }

        public async Task UpdateMenuProductPriceAsync(MenuProductPriceModel menuProductPrice)
        {
            _context.MenuProductPrice.Update(menuProductPrice);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMenuProductPriceAsync(int id)
        {
            var menuProductPrice = await _context.MenuProductPrice.FindAsync(id);
            if (menuProductPrice != null)
            {
                _context.MenuProductPrice.Remove(menuProductPrice);
                await _context.SaveChangesAsync();
            }
        }
    }
}
