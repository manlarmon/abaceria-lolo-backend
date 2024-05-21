using AbaceriaLolo.Backend.Infrastructure.Data;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace AbaceriaLolo.Backend.Infrastructure.Repositories
{
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
                .ToListAsync();
        }

        public async Task<MenuSectionModel> GetMenuSectionByIdAsync(int id)
        {
            return await _context.MenuSection
                .Include(ms => ms.MenuProducts)
                .FirstOrDefaultAsync(ms => ms.MenuSectionId == id);
        }

        public async Task<MenuSectionModel> CreateMenuSectionAsync(MenuSectionModel menuSection)
        {
            await _context.MenuSection.AddAsync(menuSection);
            await _context.SaveChangesAsync();
            return menuSection;
        }

        public async Task UpdateMenuSectionAsync(MenuSectionModel menuSection)
        {
            var existingEntity = await _context.MenuSection.FindAsync(menuSection.MenuSectionId);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(menuSection);
                await _context.SaveChangesAsync();
            }
            else
            {
                // Opcional: Manejar el caso en que la entidad no existe
                throw new Exception("MenuSection not found");
            }
        }

        public async Task DeleteMenuSectionAsync(int id)
        {
            var menuSection = await GetMenuSectionByIdAsync(id);
            if (menuSection != null)
            {
                _context.MenuSection.Remove(menuSection);
                await _context.SaveChangesAsync();
            }
        }
    }
}
