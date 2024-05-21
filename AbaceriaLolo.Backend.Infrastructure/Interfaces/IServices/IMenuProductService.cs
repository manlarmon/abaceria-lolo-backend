using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;

namespace AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices
{
    public interface IMenuProductService
    {
        Task<IEnumerable<MenuProductModel>> GetAllMenuProductsAsync();
        Task<MenuProductModel> GetMenuProductByIdAsync(int id);
        Task<MenuProductModel> CreateMenuProductAsync(MenuProductDTO menuProduct);
        Task UpdateMenuProductAsync(MenuProductModel menuProduct);
        Task DeleteMenuProductAsync(int id);
    }
}
