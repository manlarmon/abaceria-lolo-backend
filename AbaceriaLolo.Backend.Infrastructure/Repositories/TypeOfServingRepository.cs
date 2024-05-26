using AbaceriaLolo.Backend.Infrastructure.Data;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class TypeOfServingRepository : ITypeOfServingRepository
{
    private readonly DataContext _context;

    public TypeOfServingRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TypeOfServingModel>> GetAllTypesOfServingAsync()
    {
        return await _context.TypeOfServing.ToListAsync();
    }

    public async Task<TypeOfServingModel> GetTypeOfServingByIdAsync(int id)
    {
        return await _context.TypeOfServing.FindAsync(id);
    }

    public async Task<TypeOfServingModel> CreateTypeOfServingAsync(TypeOfServingModel typeOfServing)
    {
        _context.TypeOfServing.Add(typeOfServing);
        await _context.SaveChangesAsync();
        return typeOfServing;
    }

    public async Task<TypeOfServingModel> UpdateTypeOfServingAsync(TypeOfServingModel typeOfServing)
    {
        var existingType = await _context.TypeOfServing.FindAsync(typeOfServing.TypeOfServingId);
        if (existingType != null)
        {
            _context.Entry(existingType).CurrentValues.SetValues(typeOfServing);
            await _context.SaveChangesAsync();
        }
        return typeOfServing;
    }

    public async Task DeleteTypeOfServingAsync(int id)
    {
        var typeOfServing = await _context.TypeOfServing.FindAsync(id);
        if (typeOfServing != null)
        {
            _context.TypeOfServing.Remove(typeOfServing);
            await _context.SaveChangesAsync();
        }
    }
}
