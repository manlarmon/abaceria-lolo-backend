using AbaceriaLolo.Backend.Infrastructure.Data;
using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Business.Services
{
    public class MenuProductPriceService : IMenuProductPriceService
    {
        private readonly IMenuProductPriceRepository _menuProductPriceRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public MenuProductPriceService(IMenuProductPriceRepository menuProductPriceRepository, IMapper mapper, DataContext context)
        {
            _menuProductPriceRepository = menuProductPriceRepository;
            _mapper = mapper;
            _context = context;
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

        public async Task AdjustPricesForSectionAsync(int sectionId, decimal adjustment)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var products = await _context.MenuProduct
                        .Where(mp => mp.MenuSectionId == sectionId)
                        .Include(mp => mp.MenuProductPrice)
                        .ToListAsync();

                    foreach (var product in products)
                    {
                        foreach (var price in product.MenuProductPrice)
                        {
                            price.Price += adjustment;
                            _context.MenuProductPrice.Update(price);
                        }
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }
    }
}
