using AbaceriaLolo.Backend.Infrastructure.Data.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices
{
    public interface IMenuSectionService
    {
        Task<IEnumerable<MenuSectionDTO>> GetAllMenuSectionsAsync();
        Task<MenuSectionDTO> GetMenuSectionByIdAsync(int id);
        Task<MenuSectionDTO> CreateMenuSectionAsync(MenuSectionDTO menuSection);
        Task UpdateMenuSectionAsync(MenuSectionDTO menuSection);
        Task DeleteMenuSectionAsync(int id);
    }
}
