using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices
{
    public interface IMenuProductPriceService
    {
        Task<IEnumerable<MenuProductPriceModel>> GetAllMenuProductPricesAsync();
        Task<MenuProductPriceModel> GetMenuProductPriceByIdAsync(int id);
        Task<MenuProductPriceModel> CreateMenuProductPriceAsync(MenuProductPriceModel menuProductPrice);
        Task UpdateMenuProductPriceAsync(MenuProductPriceModel menuProductPrice);
        Task DeleteMenuProductPriceAsync(int id);
    }
}
