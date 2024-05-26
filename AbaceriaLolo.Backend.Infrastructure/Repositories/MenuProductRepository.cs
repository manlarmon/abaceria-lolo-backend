using AbaceriaLolo.Backend.Infrastructure.Data;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class MenuProductRepository : IMenuProductRepository
{
    private readonly DataContext _context;

    public MenuProductRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MenuProductModel>> GetAllMenuProductsAsync()
    {
        return await _context.MenuProduct
            .Include(mp => mp.MenuProductPrice)
            .ThenInclude(mpp => mpp.TypeOfServing)
            .Include(mp => mp.AllergenMenuProduct)
            .ThenInclude(amp => amp.Allergen)
            .ToListAsync();
    }

    public async Task<MenuProductModel> GetMenuProductByIdAsync(int id)
    {
        return await _context.MenuProduct
            .Include(mp => mp.MenuProductPrice)
            .ThenInclude(mpp => mpp.TypeOfServing)
            .Include(mp => mp.AllergenMenuProduct)
            .ThenInclude(amp => amp.Allergen)
            .FirstOrDefaultAsync(mp => mp.MenuProductId == id);
    }

    public async Task<MenuProductModel> CreateMenuProductAsync(MenuProductModel menuProduct)
    {
        _context.MenuProduct.Add(menuProduct);
        await _context.SaveChangesAsync();
        return menuProduct;
    }

    public async Task<MenuProductModel> UpdateMenuProductAsync(MenuProductModel menuProduct)
    {
        var existingProduct = await _context.MenuProduct
            .Include(mp => mp.MenuProductPrice)
            .Include(mp => mp.AllergenMenuProduct)
            .FirstOrDefaultAsync(mp => mp.MenuProductId == menuProduct.MenuProductId);

        if (existingProduct != null)
        {
            _context.Entry(existingProduct).CurrentValues.SetValues(menuProduct);

            // Update Prices
            existingProduct.MenuProductPrice.Clear();
            foreach (var price in menuProduct.MenuProductPrice)
            {
                var trackedTypeOfServing = _context.TypeOfServing.Local.FirstOrDefault(ts => ts.TypeOfServingId == price.TypeOfServingId) ?? price.TypeOfServing;
                price.TypeOfServing = trackedTypeOfServing;
                existingProduct.MenuProductPrice.Add(price);
            }

            // Update Allergens
            existingProduct.AllergenMenuProduct.Clear();
            foreach (var allergen in menuProduct.AllergenMenuProduct)
            {
                var trackedAllergen = _context.Allergen.Local.FirstOrDefault(a => a.AllergenId == allergen.AllergenId) ?? allergen.Allergen;
                allergen.Allergen = trackedAllergen;
                existingProduct.AllergenMenuProduct.Add(allergen);
            }

            await _context.SaveChangesAsync();
        }
        return menuProduct;
    }

    public async Task DeleteMenuProductAsync(int id)
    {
        var menuProduct = await _context.MenuProduct.FindAsync(id);
        if (menuProduct != null)
        {
            _context.MenuProduct.Remove(menuProduct);
            await _context.SaveChangesAsync();
        }
    }
}
