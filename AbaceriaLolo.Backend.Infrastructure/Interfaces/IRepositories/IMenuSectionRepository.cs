using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories
{
    public interface IMenuSectionRepository
    {
        Task<IEnumerable<MenuSectionModel>> GetAllMenuSectionsAsync();
        Task<MenuSectionModel> GetMenuSectionByIdAsync(int id);
        Task<MenuSectionModel> CreateMenuSectionAsync(MenuSectionModel menuSection);
        Task<MenuSectionModel> UpdateMenuSectionAsync(MenuSectionModel menuSection);
        Task DeleteMenuSectionAsync(int id);
    }
}
