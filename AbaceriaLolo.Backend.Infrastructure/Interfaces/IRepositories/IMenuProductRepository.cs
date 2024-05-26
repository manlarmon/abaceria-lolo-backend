using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories
{
    public interface IMenuProductRepository
    {
        Task<IEnumerable<MenuProductModel>> GetAllMenuProductsAsync();
        Task<MenuProductModel> GetMenuProductByIdAsync(int id);
        Task<MenuProductModel> CreateMenuProductAsync(MenuProductModel menuProduct);
        Task<MenuProductModel> UpdateMenuProductAsync(MenuProductModel menuProduct);
        Task DeleteMenuProductAsync(int id);
    }
}
