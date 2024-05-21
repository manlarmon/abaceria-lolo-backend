using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Business.Services
{
    public class MenuProductPriceService : IMenuProductPriceService
    {
        private readonly IMenuProductPriceRepository _menuProductPriceRepository;

        public MenuProductPriceService(IMenuProductPriceRepository menuProductPriceRepository)
        {
            _menuProductPriceRepository = menuProductPriceRepository;
        }

        public async Task<IEnumerable<MenuProductPriceModel>> GetAllMenuProductPricesAsync()
        {
            return await _menuProductPriceRepository.GetAllMenuProductPricesAsync();
        }

        public async Task<MenuProductPriceModel> GetMenuProductPriceByIdAsync(int id)
        {
            return await _menuProductPriceRepository.GetMenuProductPriceByIdAsync(id);
        }

        public async Task<MenuProductPriceModel> CreateMenuProductPriceAsync(MenuProductPriceModel menuProductPrice)
        {
            return await _menuProductPriceRepository.CreateMenuProductPriceAsync(menuProductPrice);
        }

        public async Task UpdateMenuProductPriceAsync(MenuProductPriceModel menuProductPrice)
        {
            await _menuProductPriceRepository.UpdateMenuProductPriceAsync(menuProductPrice);
        }

        public async Task DeleteMenuProductPriceAsync(int id)
        {
            await _menuProductPriceRepository.DeleteMenuProductPriceAsync(id);
        }
    }
}
