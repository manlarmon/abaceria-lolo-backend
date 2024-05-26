using AbaceriaLolo.Backend.Infrastructure.Data;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Repositories
{
    public class AllergenMenuProductRepository : IAllergenMenuProductRepository
    {
        private readonly DataContext _context;

        public AllergenMenuProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AllergenMenuProductModel>> GetAllAllergenMenuProductsAsync()
        {
            return await _context.AllergenMenuProduct
                .Include(amp => amp.Allergen) // Include related entities if needed
                .Include(amp => amp.MenuProduct) // Include related entities if needed
                .ToListAsync();
        }

        public async Task<AllergenMenuProductModel> GetAllergenMenuProductByIdAsync(int id)
        {
            return await _context.AllergenMenuProduct
                .Include(amp => amp.Allergen) // Include related entities if needed
                .Include(amp => amp.MenuProduct) // Include related entities if needed
                .FirstOrDefaultAsync(amp => amp.AllergenMenuProductId == id);
        }

        public async Task<AllergenMenuProductModel> CreateAllergenMenuProductAsync(AllergenMenuProductModel allergenMenuProduct)
        {
            await _context.AllergenMenuProduct.AddAsync(allergenMenuProduct);
            await _context.SaveChangesAsync();
            return allergenMenuProduct;
        }

        public async Task UpdateAllergenMenuProductAsync(AllergenMenuProductModel allergenMenuProduct)
        {
            _context.AllergenMenuProduct.Update(allergenMenuProduct);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllergenMenuProductAsync(int id)
        {
            var allergenMenuProduct = await _context.AllergenMenuProduct.FindAsync(id);
            if (allergenMenuProduct != null)
            {
                _context.AllergenMenuProduct.Remove(allergenMenuProduct);
                await _context.SaveChangesAsync();
            }
        }
    }
}
