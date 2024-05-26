using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices
{
    public interface IMenuProductService
    {
        Task<IEnumerable<MenuProductDTO>> GetAllMenuProductsAsync();
        Task<MenuProductDTO> GetMenuProductByIdAsync(int id);
        Task<MenuProductDTO> CreateMenuProductAsync(MenuProductDTO menuProduct);
        Task UpdateMenuProductAsync(MenuProductDTO menuProduct);
        Task DeleteMenuProductAsync(int id);
    }
}
