using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;

namespace AbaceriaLolo.Backend.Business.Services
{
    public class MenuSectionService : IMenuSectionService
    {
        private readonly IMenuSectionRepository _menuSectionRepository;

        public MenuSectionService(IMenuSectionRepository menuSectionRepository)
        {
            _menuSectionRepository = menuSectionRepository;
        }

        public async Task<IEnumerable<MenuSectionModel>> GetAllMenuSectionsAsync()
        {
            return await _menuSectionRepository.GetAllMenuSectionsAsync();
        }

        public async Task<MenuSectionModel> GetMenuSectionByIdAsync(int id)
        {
            return await _menuSectionRepository.GetMenuSectionByIdAsync(id);
        }

        public async Task<MenuSectionModel> CreateMenuSectionAsync(MenuSectionModel menuSection)
        {
            return await _menuSectionRepository.CreateMenuSectionAsync(menuSection);
             
        }

        public async Task UpdateMenuSectionAsync(MenuSectionModel menuSection)
        {
            await _menuSectionRepository.UpdateMenuSectionAsync(menuSection);
        }

        public async Task DeleteMenuSectionAsync(int id)
        {
            await _menuSectionRepository.DeleteMenuSectionAsync(id);
        }
    }
}
