using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using AbaceriaLolo.Backend.Infrastructure.Repositories;

namespace AbaceriaLolo.Backend.Business.Services
{
    public class MenuProductService : IMenuProductService
    {
        private readonly IMenuProductRepository _menuProductRepository;

        public MenuProductService(IMenuProductRepository menuProductRepository)
        {
            _menuProductRepository = menuProductRepository;
        }

        public async Task<IEnumerable<MenuProductModel>> GetAllMenuProductsAsync()
        {
            return await _menuProductRepository.GetAllMenuProductsAsync();
        }

        public async Task<MenuProductModel> GetMenuProductByIdAsync(int id)
        {
            return await _menuProductRepository.GetMenuProductByIdAsync(id);
        }

        public async Task<MenuProductModel> CreateMenuProductAsync(MenuProductDTO menuProduct)
        {

            var menuProductModel = new MenuProductModel
            {
                MenuProductId = 0,
                MenuProductName = menuProduct.MenuProductName,
                MenuSectionId = menuProduct.MenuSectionId,
                Order = menuProduct.Order

            };

            return await _menuProductRepository.CreateMenuProductAsync(menuProductModel);
        }

        public async Task UpdateMenuProductAsync(MenuProductModel menuProduct)
        {
            await _menuProductRepository.UpdateMenuProductAsync(menuProduct);
        }

        public async Task DeleteMenuProductAsync(int id)
        {
            await _menuProductRepository.DeleteMenuProductAsync(id);
        }

    }
}
