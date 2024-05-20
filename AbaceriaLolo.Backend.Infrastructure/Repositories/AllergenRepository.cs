using AbaceriaLolo.Backend.Infrastructure.Data;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace AbaceriaLolo.Backend.Infrastructure.Repositories
{
    public class AllergenRepository : IAllergenRepository
    {
        private readonly DataContext _context;

        public AllergenRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AllergenModel>> GetAllAllergensAsync()
        {
            return await _context.Allergen.ToListAsync();
        }

        public async Task<AllergenModel> GetAllergenByIdAsync(int id)
        {
            return await _context.Allergen.FirstOrDefaultAsync(ms => ms.AllergenId == id);
        }

        public async Task CreateAllergenAsync(AllergenModel allergen)
        {
            _context.Allergen.Add(allergen);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAllergenAsync(AllergenModel allergen, int id)
        {
            _context.Entry(allergen).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllergenAsync(int id)
        {
            var allergen = await GetAllergenByIdAsync(id);
            if (allergen != null)
            {
                _context.Allergen.Remove(allergen);
                await _context.SaveChangesAsync();
            }
        }
    }
}
