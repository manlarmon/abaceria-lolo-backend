using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
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

        public async Task<MenuSectionModel> CreateMenuSectionAsync(MenuSectionDTO menuSection)
        {
            var menuSectionModel = new MenuSectionModel
            {
                MenuSectionId = 0,
                MenuSectionName = menuSection.MenuSectionName,
                Order = menuSection.Order
            };

            return await _menuSectionRepository.CreateMenuSectionAsync(menuSectionModel);
             
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
