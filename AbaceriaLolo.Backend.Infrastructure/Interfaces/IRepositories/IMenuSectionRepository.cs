using AbaceriaLolo.Backend.Infrastructure.Data.Models;

namespace AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories
{
    public interface IMenuSectionRepository
    {
        Task<IEnumerable<MenuSectionModel>> GetAllMenuSectionsAsync();
        Task<MenuSectionModel> GetMenuSectionByIdAsync(int id);
        Task CreateMenuSectionAsync(MenuSectionModel menuSection);
        Task UpdateMenuSectionAsync(MenuSectionModel menuSection, int id);
        Task DeleteMenuSectionAsync(int id);
    }
}
