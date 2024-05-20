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
            return await _context.MenuSection.ToListAsync();
        }

        public async Task<MenuSectionModel> GetMenuSectionByIdAsync(int id)
        {
            return await _context.MenuSection.FirstOrDefaultAsync(ms => ms.MenuSectionId == id);
        }

        public async Task CreateMenuSectionAsync(MenuSectionModel menuSection)
        {
            await _context.MenuSection.AddAsync(menuSection);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMenuSectionAsync(MenuSectionModel menuSection, int id)
        {
            _context.MenuSection.Update(menuSection);
            await _context.SaveChangesAsync();
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
