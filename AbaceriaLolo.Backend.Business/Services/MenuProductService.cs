using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Business.Services
{
    public class MenuProductService : IMenuProductService
    {
        private readonly IMenuProductRepository _menuProductRepository;
        private readonly IMapper _mapper;

        public MenuProductService(IMenuProductRepository menuProductRepository, IMapper mapper)
        {
            _menuProductRepository = menuProductRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MenuProductDTO>> GetAllMenuProductsAsync()
        {
            var menuProducts = await _menuProductRepository.GetAllMenuProductsAsync();
            return _mapper.Map<IEnumerable<MenuProductDTO>>(menuProducts);
        }

        public async Task<MenuProductDTO> GetMenuProductByIdAsync(int id)
        {
            var menuProduct = await _menuProductRepository.GetMenuProductByIdAsync(id);
            return _mapper.Map<MenuProductDTO>(menuProduct);
        }

        public async Task<MenuProductDTO> CreateMenuProductAsync(MenuProductDTO menuProduct)
        {
            var menuProductModel = _mapper.Map<MenuProductModel>(menuProduct);
            var createdMenuProduct = await _menuProductRepository.CreateMenuProductAsync(menuProductModel);
            return _mapper.Map<MenuProductDTO>(createdMenuProduct);
        }

        public async Task UpdateMenuProductAsync(MenuProductDTO menuProduct)
        {
            var menuProductModel = _mapper.Map<MenuProductModel>(menuProduct);
            await _menuProductRepository.UpdateMenuProductAsync(menuProductModel);
        }

        public async Task DeleteMenuProductAsync(int id)
        {
            await _menuProductRepository.DeleteMenuProductAsync(id);
        }
    }
}
