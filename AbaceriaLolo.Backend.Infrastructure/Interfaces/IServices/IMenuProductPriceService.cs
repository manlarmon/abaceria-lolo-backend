using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices
{
    public interface IMenuProductPriceService
    {
        Task<IEnumerable<MenuProductPriceDTO>> GetAllMenuProductPricesAsync();
        Task<MenuProductPriceDTO> GetMenuProductPriceByIdAsync(int id);
        Task<MenuProductPriceDTO> CreateMenuProductPriceAsync(MenuProductPriceDTO menuProductPrice);
        Task UpdateMenuProductPriceAsync(MenuProductPriceDTO menuProductPrice);
        Task DeleteMenuProductPriceAsync(int id);
    }
}
