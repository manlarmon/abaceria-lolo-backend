using AbaceriaLolo.Backend.Infrastructure.Data;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        return await _context.Allergen.FindAsync(id);
    }

    public async Task<AllergenModel> CreateAllergenAsync(AllergenModel allergen)
    {
        _context.Allergen.Add(allergen);
        await _context.SaveChangesAsync();
        return allergen;
    }

    public async Task<AllergenModel> UpdateAllergenAsync(AllergenModel allergen)
    {
        var existingAllergen = await _context.Allergen.FindAsync(allergen.AllergenId);
        if (existingAllergen != null)
        {
            _context.Entry(existingAllergen).CurrentValues.SetValues(allergen);
            await _context.SaveChangesAsync();
        }
        return allergen;
    }

    public async Task DeleteAllergenAsync(int id)
    {
        var allergen = await _context.Allergen.FindAsync(id);
        if (allergen != null)
        {
            _context.Allergen.Remove(allergen);
            await _context.SaveChangesAsync();
        }
    }

}
