using AbaceriaLolo.Backend.Infrastructure.Data.Models;

namespace AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories
{
    public interface IMenuSectionRepository
    {
        Task<IEnumerable<MenuSectionModel>> GetAllMenuSectionsAsync();
        Task<MenuSectionModel> GetMenuSectionByIdAsync(int id);
        Task<MenuSectionModel> CreateMenuSectionAsync(MenuSectionModel menuSection);
        Task UpdateMenuSectionAsync(MenuSectionModel menuSection);
        Task DeleteMenuSectionAsync(int id);
    }
}
