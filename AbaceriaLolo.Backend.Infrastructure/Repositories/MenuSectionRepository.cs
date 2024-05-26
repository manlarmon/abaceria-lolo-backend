using AbaceriaLolo.Backend.Infrastructure.Data;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class MenuSectionRepository : IMenuSectionRepository
{
    private readonly DataContext _context;

    public MenuSectionRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MenuSectionModel>> GetAllMenuSectionsAsync()
    {
        return await _context.MenuSection
            .Include(ms => ms.MenuProducts)
                .ThenInclude(mp => mp.MenuProductPrice)
            .Include(ms => ms.MenuProducts)
                .ThenInclude(mp => mp.AllergenMenuProduct)
            .ToListAsync();
    }

    public async Task<MenuSectionModel> GetMenuSectionByIdAsync(int id)
    {
        return await _context.MenuSection
            .Include(ms => ms.MenuProducts)
                .ThenInclude(mp => mp.MenuProductPrice)
            .Include(ms => ms.MenuProducts)
                .ThenInclude(mp => mp.AllergenMenuProduct)
            .FirstOrDefaultAsync(ms => ms.MenuSectionId == id);
    }

    public async Task<MenuSectionModel> CreateMenuSectionAsync(MenuSectionModel menuSection)
    {
        _context.MenuSection.Add(menuSection);
        await _context.SaveChangesAsync();
        return menuSection;
    }

    public async Task<MenuSectionModel> UpdateMenuSectionAsync(MenuSectionModel menuSection)
    {
        var existingSection = await _context.MenuSection
            .Include(ms => ms.MenuProducts)
            .FirstOrDefaultAsync(ms => ms.MenuSectionId == menuSection.MenuSectionId);

        if (existingSection != null)
        {
            _context.Entry(existingSection).CurrentValues.SetValues(menuSection);

            // Update Menu Products
            foreach (var product in menuSection.MenuProducts)
            {
                var existingProduct = existingSection.MenuProducts
                    .FirstOrDefault(mp => mp.MenuProductId == product.MenuProductId);

                if (existingProduct == null)
                {
                    existingSection.MenuProducts.Add(product);
                }
                else
                {
                    _context.Entry(existingProduct).CurrentValues.SetValues(product);
                }
            }

            await _context.SaveChangesAsync();
        }
        return menuSection;
    }

    public async Task DeleteMenuSectionAsync(int id)
    {
        var menuSection = await _context.MenuSection.FindAsync(id);
        if (menuSection != null)
        {
            _context.MenuSection.Remove(menuSection);
            await _context.SaveChangesAsync();
        }
    }
}
