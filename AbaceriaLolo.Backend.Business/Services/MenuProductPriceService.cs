using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Business.Services
{
    public class MenuProductPriceService : IMenuProductPriceService
    {
        private readonly IMenuProductPriceRepository _menuProductPriceRepository;
        private readonly IMapper _mapper;

        public MenuProductPriceService(IMenuProductPriceRepository menuProductPriceRepository, IMapper mapper)
        {
            _menuProductPriceRepository = menuProductPriceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MenuProductPriceDTO>> GetAllMenuProductPricesAsync()
        {
            var menuProductPrices = await _menuProductPriceRepository.GetAllMenuProductPricesAsync();
            return _mapper.Map<IEnumerable<MenuProductPriceDTO>>(menuProductPrices);
        }

        public async Task<MenuProductPriceDTO> GetMenuProductPriceByIdAsync(int id)
        {
            var menuProductPrice = await _menuProductPriceRepository.GetMenuProductPriceByIdAsync(id);
            return _mapper.Map<MenuProductPriceDTO>(menuProductPrice);
        }

        public async Task<MenuProductPriceDTO> CreateMenuProductPriceAsync(MenuProductPriceDTO menuProductPrice)
        {
            var menuProductPriceModel = _mapper.Map<MenuProductPriceModel>(menuProductPrice);
            var createdMenuProductPrice = await _menuProductPriceRepository.CreateMenuProductPriceAsync(menuProductPriceModel);
            return _mapper.Map<MenuProductPriceDTO>(createdMenuProductPrice);
        }

        public async Task UpdateMenuProductPriceAsync(MenuProductPriceDTO menuProductPrice)
        {
            var menuProductPriceModel = _mapper.Map<MenuProductPriceModel>(menuProductPrice);
            await _menuProductPriceRepository.UpdateMenuProductPriceAsync(menuProductPriceModel);
        }

        public async Task DeleteMenuProductPriceAsync(int id)
        {
            await _menuProductPriceRepository.DeleteMenuProductPriceAsync(id);
        }
    }
}
