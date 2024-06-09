using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using AbaceriaLolo.Backend.Infrastructure.Data;

public class InventoryProductRepository : IInventoryProductRepository
{
    private readonly DataContext _context;

    public InventoryProductRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<InventoryProductModel>> GetAllInventoryProductsAsync()
    {
        return await _context.InventoryProduct.ToListAsync();
    }

    public async Task<InventoryProductModel> GetInventoryProductByIdAsync(int id)
    {
        return await _context.InventoryProduct.FindAsync(id);
    }

    public async Task<InventoryProductModel> CreateInventoryProductAsync(InventoryProductModel inventoryProduct)
    {
        _context.InventoryProduct.Add(inventoryProduct);
        await _context.SaveChangesAsync();
        return inventoryProduct;
    }

    public async Task<InventoryProductModel> UpdateInventoryProductAsync(InventoryProductModel inventoryProduct)
    {
        var existingProduct = await _context.InventoryProduct
                                            .FirstOrDefaultAsync(p => p.InventoryProductId == inventoryProduct.InventoryProductId);

        if (existingProduct != null)
        {
            _context.Entry(existingProduct).CurrentValues.SetValues(inventoryProduct);
            await _context.SaveChangesAsync();
        }

        return existingProduct;
    }

    public async Task DeleteInventoryProductAsync(int id)
    {
        var product = await _context.InventoryProduct.FindAsync(id);
        if (product != null)
        {
            _context.InventoryProduct.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
