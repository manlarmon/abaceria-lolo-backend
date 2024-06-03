using AbaceriaLolo.Backend.Infrastructure.Data;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            .Include(mpp => mpp.TypeOfServing)
            .ToListAsync();
    }

    public async Task<MenuProductPriceModel> GetMenuProductPriceByIdAsync(int id)
    {
        return await _context.MenuProductPrice
            .Include(mpp => mpp.TypeOfServing)
            .FirstOrDefaultAsync(mpp => mpp.MenuProductPriceId == id);
    }

    public async Task<MenuProductPriceModel> CreateMenuProductPriceAsync(MenuProductPriceModel menuProductPrice)
    {
        _context.MenuProductPrice.Add(menuProductPrice);
        await _context.SaveChangesAsync();
        return menuProductPrice;
    }

    public async Task UpdateMenuProductPriceAsync(MenuProductPriceModel menuProductPrice)
    {
        _context.Entry(menuProductPrice).State = EntityState.Modified;
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

    // Implementación del método para actualizar múltiples precios
    public async Task UpdateMenuProductPricesAsync(IEnumerable<MenuProductPriceModel> menuProductPrices)
    {
        _context.MenuProductPrice.UpdateRange(menuProductPrices);
        await _context.SaveChangesAsync();
    }
}
