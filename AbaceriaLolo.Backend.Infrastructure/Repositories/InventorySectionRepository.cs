using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using AbaceriaLolo.Backend.Infrastructure.Data;

public class InventorySectionRepository : IInventorySectionRepository
{
    private readonly DataContext _context;

    public InventorySectionRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<InventorySectionModel>> GetAllInventorySectionsAsync()
    {
        return await _context.InventorySection
                             .Include(s => s.InventoryProducts)
                             .ToListAsync();
    }

    public async Task<InventorySectionModel> GetInventorySectionByIdAsync(int id)
    {
        return await _context.InventorySection
                             .Include(s => s.InventoryProducts)
                             .FirstOrDefaultAsync(s => s.InventorySectionId == id);
    }

    public async Task<InventorySectionModel> CreateInventorySectionAsync(InventorySectionModel inventorySection)
    {
        _context.InventorySection.Add(inventorySection);
        await _context.SaveChangesAsync();
        return inventorySection;
    }

    public async Task<InventorySectionModel> UpdateInventorySectionAsync(InventorySectionModel inventorySection)
    {
        var existingSection = await _context.InventorySection
                                            .Include(s => s.InventoryProducts)
                                            .FirstOrDefaultAsync(s => s.InventorySectionId == inventorySection.InventorySectionId);

        if (existingSection != null)
        {
            // Update the section details
            _context.Entry(existingSection).CurrentValues.SetValues(inventorySection);

            // Remove existing products and add the new ones
            _context.InventoryProduct.RemoveRange(existingSection.InventoryProducts);
            await _context.SaveChangesAsync(); // Save changes to apply the deletions
            existingSection.InventoryProducts = inventorySection.InventoryProducts;
            await _context.SaveChangesAsync();
        }

        return existingSection;
    }

    public async Task DeleteInventorySectionAsync(int id)
    {
        var section = await _context.InventorySection.FindAsync(id);
        if (section != null)
        {
            _context.InventorySection.Remove(section);
            await _context.SaveChangesAsync();
        }
    }
}
