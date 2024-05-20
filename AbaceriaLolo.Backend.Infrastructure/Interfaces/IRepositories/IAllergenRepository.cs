using AbaceriaLolo.Backend.Infrastructure.Data.Models;

namespace AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories
{
    public interface IAllergenRepository
    {
        Task<IEnumerable<AllergenModel>> GetAllAllergensAsync();
        Task<AllergenModel> GetAllergenByIdAsync(int id);
        Task CreateAllergenAsync(AllergenModel allergen);
        Task UpdateAllergenAsync(AllergenModel allergen, int id);
        Task DeleteAllergenAsync(int id);

    }
}
