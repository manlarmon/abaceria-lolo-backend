using AbaceriaLolo.Backend.Infrastructure.Data.Models;

namespace AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories
{
    public interface IMenuProductRepository
    {
        Task<IEnumerable<MenuProductModel>> GetAllMenuProductsAsync();
        Task<MenuProductModel> GetMenuProductByIdAsync(int menuProductId);
        Task<MenuProductModel> CreateMenuProductAsync(MenuProductModel menuProduct);
        Task UpdateMenuProductAsync(MenuProductModel menuProduct);
        Task DeleteMenuProductAsync(int menuProductId);
    }
}
