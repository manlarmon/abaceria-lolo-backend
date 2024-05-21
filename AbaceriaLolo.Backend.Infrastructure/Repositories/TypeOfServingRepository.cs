using AbaceriaLolo.Backend.Infrastructure.Data;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Repositories
{
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
            await _context.TypeOfServing.AddAsync(typeOfServing);
            await _context.SaveChangesAsync();
            return typeOfServing;
        }

        public async Task UpdateTypeOfServingAsync(TypeOfServingModel typeOfServing)
        {
            var existingEntity = await _context.TypeOfServing.FindAsync(typeOfServing.TypeOfServingId);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(typeOfServing);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTypeOfServingAsync(int id)
        {
            var typeOfServing = await GetTypeOfServingByIdAsync(id);
            if (typeOfServing != null)
            {
                _context.TypeOfServing.Remove(typeOfServing);
                await _context.SaveChangesAsync();
            }
        }
    }
}
